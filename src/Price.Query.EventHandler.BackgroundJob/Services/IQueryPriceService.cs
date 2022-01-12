using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AElf.Contracts.Price;
using AElf.Types;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Price.Query.AElfWeb.Managers;
using Price.Query.EventHandler.BackgroundJob.Options;
using Volo.Abp.DependencyInjection;

namespace Price.Query.EventHandler.BackgroundJob.Services
{
    public interface IQueryPriceService
    {
        Task QueryExchangeTokenPrice();
        Task QuerySwapTokenPrice(IEnumerable<TokenPair> tokenPairs);
    }

    public class DefaultQueryPriceService : IQueryPriceService, ITransientDependency
    {
        private readonly ILogger<DefaultQueryPriceService> _logger;
        private readonly PriceQueryOptions _priceQueryOptions;
        private readonly ExchangeQueryOptions _exchangeQueryOptions;
        private readonly TokenSwapQueryOptions _tokenSwapQueryOptions;

        public DefaultQueryPriceService(ILogger<DefaultQueryPriceService> logger,
            IOptionsSnapshot<PriceQueryOptions> priceQueryOptions,
            IOptionsSnapshot<ExchangeQueryOptions> exchangeQueryOptions,
            IOptionsSnapshot<TokenSwapQueryOptions> tokenSwapQueryOptions)
        {
            _logger = logger;
            _priceQueryOptions = priceQueryOptions.Value;
            _exchangeQueryOptions = exchangeQueryOptions.Value;
            _tokenSwapQueryOptions = tokenSwapQueryOptions.Value;
        }

        public async Task QueryExchangeTokenPrice()
        {
            if (!_priceQueryOptions.IsQuery)
            {
                return;
            }

            foreach (var tokenPair in _priceQueryOptions.ExchangeTokenPairs)
            {
                var queryInput = new QueryTokenPriceInput
                {
                    TokenSymbol = tokenPair.TokenSymbol,
                    TargetTokenSymbol = tokenPair.UnderlyingTokenSymbol,
                    AggregatorContractAddress = Address.FromBase58(_exchangeQueryOptions.AggregatorContractAddress),
                    AggregateThreshold = _exchangeQueryOptions.AggregateThreshold,
                    DesignatedNodes = {_exchangeQueryOptions.DesignatedNodes.Select(Address.FromBase58).ToArray()}
                };
                await SendQueryAsync(tokenPair.TokenSymbol, tokenPair.UnderlyingTokenSymbol, "QueryExchangeTokenPrice",
                    queryInput);
            }
        }

        public async Task QuerySwapTokenPrice(IEnumerable<TokenPair> tokenPairs)
        {
            if (!_priceQueryOptions.IsQuery)
            {
                return;
            }
            
            foreach (var tokenPair in tokenPairs)
            {
                var queryInput = new QueryTokenPriceInput
                {
                    TokenSymbol = tokenPair.TokenSymbol,
                    TargetTokenSymbol = tokenPair.UnderlyingTokenSymbol,
                    AggregatorContractAddress = Address.FromBase58(_tokenSwapQueryOptions.AggregatorContractAddress),
                    AggregateThreshold = _tokenSwapQueryOptions.AggregateThreshold,
                    DesignatedNodes = {_tokenSwapQueryOptions.DesignatedNodes.Select(Address.FromBase58).ToArray()}
                };

                await SendQueryAsync(tokenPair.TokenSymbol, tokenPair.UnderlyingTokenSymbol, "QuerySwapTokenPrice",
                    queryInput);
            }
        }

        private Task SendQueryAsync(string tokenSymbol, string underlyingTokenSymbol, string targetMethodName,
            QueryTokenPriceInput queryInput)
        {
            _logger.LogInformation(
                $"Querying Price, Token Symbol {tokenSymbol}, Underlying Token Symbol {underlyingTokenSymbol}");
            var node = new NodeManager(_priceQueryOptions.NodeUrl, _priceQueryOptions.AccountAddress,
                _priceQueryOptions.AccountPassword);
            _logger.LogInformation($"About to send Query transaction for token price, QueryInput: {queryInput}");
            var txId = node.SendTransaction(_priceQueryOptions.AccountAddress,
                _priceQueryOptions.PriceContractAddress, targetMethodName, queryInput);
            _logger.LogInformation($"Query tx id: {txId}");
            return Task.CompletedTask;
        }
    }
}