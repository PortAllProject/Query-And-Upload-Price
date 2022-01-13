using System.Linq;
using System.Threading.Tasks;
using AElf;
using AElf.AElfNode.EventHandler.BackgroundJob;
using AElf.AElfNode.EventHandler.BackgroundJob.EventProcessor;
using AElf.Contracts.Oracle;
using AElf.Types;
using Google.Protobuf.WellKnownTypes;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Price.Query.AElfWeb.Managers;
using Price.Query.AElfWeb.Providers;
using Price.Query.EventHandler.BackgroundJob.Options;
using Price.Query.EventHandler.BackgroundJob.Providers;

namespace Price.Query.EventHandler.BackgroundJob.Processors
{
    internal class QueryCreatedLogEventProcessor : AElfEventProcessorBase<QueryCreated>
    {
        private readonly ISaltProvider _saltProvider;
        private readonly IDataProvider _dataProvider;
        private readonly PriceQueryOptions _priceQueryOptions;
        private readonly ExchangeQueryOptions _exchangeQueryOptions;
        private readonly TokenSwapQueryOptions _tokenSwapQueryOptions;
        private readonly ILogger<QueryCreatedLogEventProcessor> _logger;

        public QueryCreatedLogEventProcessor(IOptionsSnapshot<PriceQueryOptions> priceQueryOptions,
            IOptionsSnapshot<ExchangeQueryOptions> exchangeQueryOptions,
            IOptionsSnapshot<TokenSwapQueryOptions> tokenSwapQueryOptions,
            ISaltProvider saltProvider, IDataProvider dataProvider, ILogger<QueryCreatedLogEventProcessor> logger)
        {
            _saltProvider = saltProvider;
            _dataProvider = dataProvider;
            _logger = logger;
            _priceQueryOptions = priceQueryOptions.Value;
            _exchangeQueryOptions = exchangeQueryOptions.Value;
            _tokenSwapQueryOptions = tokenSwapQueryOptions.Value;
        }

        protected override async Task HandleEventAsync(QueryCreated queryCreated, EventContext txInfoDto)
        {
            if (txInfoDto.Status != PriceQueryConstants.MinedStatus)
            {
                return;
            }
            
            if (!_priceQueryOptions.IsCommitData)
            {
                return;
            }

            _logger.LogInformation(queryCreated.ToString());
            var title = queryCreated.QueryInfo.Title;
            var data = string.Empty;
            var timestamp = Timestamp.FromDateTime(txInfoDto.BlockTime);
            if (title.StartsWith("TokenSwapPrice"))
            {
                data = await GetTokenSwapPriceAsync(queryCreated, timestamp);
            }
            else if (title.StartsWith("ExchangeTokenPrice"))
            {
                data = await GetExchangeTokenPriceAsync(queryCreated, timestamp);
            }

            if (string.IsNullOrEmpty(data))
            {
                _logger.LogInformation("Failed to query token price");
                return;
            }

            CommitData(queryCreated, data, _priceQueryOptions.OracleContractAddress);
        }

        private async Task<string> GetExchangeTokenPriceAsync(QueryCreated queryCreated, Timestamp timestamp)
        {
            if (!IsAccountValidNode(queryCreated, _exchangeQueryOptions))
            {
                return string.Empty;
            }

            var data = await QueryDataAsync(queryCreated, timestamp);
            return data;
        }

        private async Task<string> GetTokenSwapPriceAsync(QueryCreated queryCreated, Timestamp timestamp)
        {
            if (!IsAccountValidNode(queryCreated, _tokenSwapQueryOptions))
            {
                return string.Empty;
            }

            var data = await QueryDataAsync(queryCreated, timestamp);
            return data;
        }

        private void CommitData(QueryCreated queryCreated, string data, string contractAddress)
        {
            var salt = _saltProvider.GetSalt(queryCreated.QueryId);
            _logger.LogInformation($"Queried data: {data}, salt: {salt}");
            var node = new NodeManager(_priceQueryOptions.NodeUrl, _priceQueryOptions.AccountAddress,
                _priceQueryOptions.AccountPassword);
            var commitInput = new CommitInput
            {
                QueryId = queryCreated.QueryId,
                Commitment = HashHelper.ConcatAndCompute(
                    HashHelper.ComputeFrom(data),
                    HashHelper.ConcatAndCompute(salt, HashHelper.ComputeFrom(_priceQueryOptions.AccountAddress)))
            };
            _logger.LogInformation($"Sending Commit tx with input: {commitInput}");
            var txId = node.SendTransaction(_priceQueryOptions.AccountAddress, contractAddress, "Commit",
                commitInput);
            _logger.LogInformation($"[Commit] Tx id {txId}");
        }

        private async Task<string> QueryDataAsync(QueryCreated queryCreated, Timestamp timestamp)
        {
            var data = await _dataProvider.GetDataAsync(queryCreated.QueryId, timestamp, queryCreated.QueryInfo.Title,
                queryCreated.QueryInfo.Options.ToList());
            if (!string.IsNullOrEmpty(data)) return data;


            _logger.LogError(queryCreated.QueryInfo.Title == "record_receipts"
                ? "Failed to record receipts from eth to aelf."
                : $"Failed to response to query {queryCreated.QueryId}.");

            return string.Empty;
        }

        private bool IsAccountValidNode(QueryCreated queryCreated, OracleQueryOptions options)
        {
            var nodeAddress = Address.FromBase58(_priceQueryOptions.AccountAddress);
            if (!queryCreated.DesignatedNodeList.Value.Contains(nodeAddress))
            {
                return false;
            }

            return _priceQueryOptions.QuerySender == queryCreated.QuerySender.ToBase58();
        }
    }
}