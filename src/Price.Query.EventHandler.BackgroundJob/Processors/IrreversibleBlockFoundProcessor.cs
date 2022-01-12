using System.Threading.Tasks;
using AElf.AElfNode.EventHandler.BackgroundJob;
using AElf.AElfNode.EventHandler.BackgroundJob.EventProcessor;
using AElf.Contracts.Consensus.AEDPoS;
using Microsoft.Extensions.Logging;
using Price.Query.EventHandler.BackgroundJob.Services;

namespace Price.Query.EventHandler.BackgroundJob.Processors
{
    internal class IrreversibleBlockFoundProcessor : AElfEventProcessorBase<IrreversibleBlockFound>
    {
        private readonly ILogger<IrreversibleBlockFoundProcessor> _logger;
        private readonly IQueryPriceService _queryPriceService;

        public IrreversibleBlockFoundProcessor(ILogger<IrreversibleBlockFoundProcessor> logger, IQueryPriceService queryPriceService)
        {
            _logger = logger;
            _queryPriceService = queryPriceService;
        }

        protected override async Task HandleEventAsync(IrreversibleBlockFound eventDetailsEto, EventContext txInfoDto)
        {
            _logger.LogInformation($"IrreversibleBlockFound: {eventDetailsEto}");
            await _queryPriceService.QueryExchangeTokenPrice();
        }

    }
}