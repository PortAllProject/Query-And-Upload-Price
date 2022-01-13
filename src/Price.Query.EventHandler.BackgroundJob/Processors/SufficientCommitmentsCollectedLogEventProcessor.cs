using System.Threading.Tasks;
using AElf.AElfNode.EventHandler.BackgroundJob;
using AElf.AElfNode.EventHandler.BackgroundJob.EventProcessor;
using AElf.Contracts.Oracle;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Price.Query.AElfWeb.Managers;
using Price.Query.AElfWeb.Providers;
using Price.Query.EventHandler.BackgroundJob.Options;
using Price.Query.EventHandler.BackgroundJob.Providers;

namespace Price.Query.EventHandler.BackgroundJob.Processors
{
    internal class
        SufficientCommitmentsCollectedLogEventProcessor : AElfEventProcessorBase<SufficientCommitmentsCollected>
    {
        private readonly ISaltProvider _saltProvider;
        private readonly IDataProvider _dataProvider;
        private readonly PriceQueryOptions _priceQueryOptions;
        private readonly ILogger<SufficientCommitmentsCollectedLogEventProcessor> _logger;

        public SufficientCommitmentsCollectedLogEventProcessor(
            ISaltProvider saltProvider, IDataProvider dataProvider,
            ILogger<SufficientCommitmentsCollectedLogEventProcessor> logger,
            IOptionsSnapshot<PriceQueryOptions> priceQueryOptions)
        {
            _saltProvider = saltProvider;
            _dataProvider = dataProvider;
            _logger = logger;
            _priceQueryOptions = priceQueryOptions.Value;
        }

        protected override async Task HandleEventAsync(SufficientCommitmentsCollected collected, EventContext txInfoDto)
        {
            if (txInfoDto.Status != PriceQueryConstants.MinedStatus)
            {
                return;
            }
            
            if (!_priceQueryOptions.IsCommitData)
            {
                return;
            }
            
            var data = await _dataProvider.GetDataAsync(collected.QueryId);
            if (string.IsNullOrEmpty(data))
            {
                _logger.LogError($"Failed to reveal data for query {collected.QueryId}.");
                return;
            }

            _logger.LogInformation($"Get data for revealing: {data}");
            var node = new NodeManager(_priceQueryOptions.NodeUrl, _priceQueryOptions.AccountAddress,
                _priceQueryOptions.AccountPassword);
            var revealInput = new RevealInput
            {
                QueryId = collected.QueryId,
                Data = data,
                Salt = _saltProvider.GetSalt(collected.QueryId)
            };
            _logger.LogInformation($"Sending Reveal tx with input: {revealInput}");
            var txId = node.SendTransaction(_priceQueryOptions.AccountAddress,
                _priceQueryOptions.OracleContractAddress, "Reveal", revealInput);
            _logger.LogInformation($"[Reveal] Tx id {txId}");
        }
    }
}