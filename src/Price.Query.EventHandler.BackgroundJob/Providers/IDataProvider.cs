using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AElf.Types;
using Awaken.Contracts.Swap;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Price.Query.AElfWeb.Extensions;
using Price.Query.AElfWeb.Managers;
using Price.Query.EventHandler.BackgroundJob.Options;
using Volo.Abp.DependencyInjection;

namespace Price.Query.EventHandler.BackgroundJob.Providers
{
    public interface IDataProvider
    {
        Task<string> GetDataAsync(Hash queryId, string title = null, List<string> options = null);
    }
    
    public class DataProvider : IDataProvider, ISingletonDependency
    {
        private readonly Dictionary<Hash, string> _dictionary;
        private readonly ILogger<DataProvider> _logger;
        private readonly PriceQueryOptions _priceQueryOptions;
        private readonly ExchangeQueryOptions _exchangeQueryOptions;
        private readonly TokenSwapQueryOptions _tokenSwapQueryOptions;
        
        
        public DataProvider(ILogger<DataProvider> logger,
            IOptionsSnapshot<PriceQueryOptions> priceQueryOptions,
            IOptionsSnapshot<ExchangeQueryOptions> exchangeQueryOptions,
            IOptionsSnapshot<TokenSwapQueryOptions> tokenSwapQueryOptions)
        {
            _logger = logger;
            _priceQueryOptions = priceQueryOptions.Value;
            _exchangeQueryOptions = exchangeQueryOptions.Value;
            _tokenSwapQueryOptions = tokenSwapQueryOptions.Value;
            _dictionary = new Dictionary<Hash, string>();
        }

        public async Task<string> GetDataAsync(Hash queryId, string title = null, List<string> options = null)
        {
            if (title == "invalid")
            {
                return "0";
            }

            if (_dictionary.TryGetValue(queryId, out var data))
            {
                return data;
            }

            if (title == null || options == null)
            {
                _logger.LogError($"No data of {queryId} for revealing.");
                return string.Empty;
            }
            
            var tokenPair = GetTokenPairs(options).First();
            string price;
            _logger.LogInformation($"Trying to query token price {tokenPair.TokenSymbol}-{tokenPair.UnderlyingTokenSymbol}");
            if (title == "ExchangeTokenPrice")
            {
                price = await GetPriceFromExchangeAsync(tokenPair.TokenSymbol, tokenPair.UnderlyingTokenSymbol);
                _logger.LogInformation($"price: {price}");
                _dictionary[queryId] = price;
                return price;
            }

            price = await GetPriceFromTokenSwapAsync(tokenPair.TokenSymbol, tokenPair.UnderlyingTokenSymbol);
            _logger.LogInformation($"price: {price}");
            _dictionary[queryId] = price;
            return price;
        }

        private async Task<string> GetDataFromTitleUrl(string title, List<string> options)
        {
            if (!title.Contains('|'))
            {
                return await GetSingleUrlDataAsync(title, options);
            }
            var urls = title.Split('|');
            var urlAttributes = options.Select(a => a.Split('|')).ToList();
            var dataList = new List<decimal>();
            for (var i = 0; i < urls.Length; i++)
            {
                var singleData =
                    await GetSingleUrlDataAsync(urls[i], urlAttributes.Select(a => a[i]).ToList());
                if (singleData.Contains("\""))
                {
                    singleData = singleData.Replace("\"", "");
                }

                if (decimal.TryParse(singleData, out var decimalData))
                {
                    _logger.LogInformation($"Add {singleData} to data list.");
                    dataList.Add(decimalData);
                }
                else
                {
                    throw new Exception($"Error during paring {singleData} to decimal");
                }
            }

            return Aggregate(dataList);
        }
        
        private string Aggregate(List<decimal> dataList)
        {
            var finalPrice = dataList.OrderBy(p => p).ToList()[dataList.Count / 2]
                .ToString(CultureInfo.InvariantCulture);

            _logger.LogInformation($"Final price: {finalPrice}");

            return finalPrice;
        }

        public async Task<string> GetSingleUrlDataAsync(string url, List<string> attributes)
        {
            _logger.LogInformation($"Querying {url} for attributes {attributes.First()} etc..");

            var data = string.Empty;
            var response = string.Empty;
            try
            {
                var client = new HttpClient {Timeout = TimeSpan.FromMinutes(2)};
                using var responseMessage = await client.GetHttpResponseMessageWithRetryAsync(url, _logger);
                response = await responseMessage.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                _logger.LogError($"Error during querying: {e.Message}");
            }

            try
            {
                _logger.LogInformation($"Trying to parse response to json: {response}");

                if (response != string.Empty)
                {
                    data = ParseJson(response, attributes);
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Error during parsing json: {response}\n{e.Message}");
                throw;
            }

            if (string.IsNullOrEmpty(data))
            {
                data = "0";
                _logger.LogError($"Failed to get {attributes.First()} from {response}, will just return 0.");

            }

            return data;
        }

        private string ParseJson(string response, List<string> attributes)
        {
            var jsonDoc = JsonDocument.Parse(response);
            var data = string.Empty;

            foreach (var attribute in attributes)
            {
                if (!attribute.Contains('/'))
                {
                    if (jsonDoc.RootElement.TryGetProperty(attribute, out var targetElement))
                    {
                        if (data == string.Empty)
                        {
                            data = targetElement.GetRawText();
                        }
                        else
                        {
                            data += $";{targetElement.GetRawText()}";
                        }
                    }
                    else
                    {
                        return data;
                    }
                }
                else
                {
                    var attrs = attribute.Split('/');
                    var targetElement = jsonDoc.RootElement.GetProperty(attrs[0]);
                    foreach (var attr in attrs.Skip(1))
                    {
                        if (!targetElement.TryGetProperty(attr, out targetElement))
                        {
                            return attr;
                        }
                    }

                    if (data == string.Empty)
                    {
                        data = targetElement.GetRawText();
                    }
                    else
                    {
                        data += $";{targetElement.GetRawText()}";
                    }
                }
            }

            return data;
        }

        private List<TokenPair> GetTokenPairs(IEnumerable<string> options)
        {
            return (from option in options
                select option.Split('-')
                into tokenPairInfoArray
                where tokenPairInfoArray.Length == 2
                select new TokenPair
                    {TokenSymbol = tokenPairInfoArray[0], UnderlyingTokenSymbol = tokenPairInfoArray[1]}).ToList();
        }

        private async Task<string> GetPriceFromExchangeAsync(string token, string underlyingToken)
        {
            return await GetSingleUrlDataAsync(_exchangeQueryOptions.DataSourceUrl,
                new List<string> {token, underlyingToken});
        }

        private async Task<string> GetPriceFromTokenSwapAsync(string token, string underlyingToken)
        {
            var node = new NodeManager(_priceQueryOptions.NodeUrl, _priceQueryOptions.AccountAddress,
                _priceQueryOptions.AccountPassword);

            var input = new GetReservesInput
            {
                SymbolPair = {$"{token}-{underlyingToken}"}
            };
            var reservePairResults = node.QueryView<GetReservesOutput>(_priceQueryOptions.AccountAddress,
                _tokenSwapQueryOptions.TokenSwapAddress, "GetReserves", input);
            if (!reservePairResults.Results.Any())
            {
                _logger.LogInformation(
                    $"Failed to query token price:{token}-{underlyingToken} on contract:{_tokenSwapQueryOptions.TokenSwapAddress}");
            }

            var tokenPairInfo = reservePairResults.Results[0];
            return tokenPairInfo.SymbolA == token
                ? ((decimal) tokenPairInfo.ReserveA / tokenPairInfo.ReserveB).ToString()
                : ((decimal) tokenPairInfo.ReserveB / tokenPairInfo.ReserveA).ToString();
        }
    }
}