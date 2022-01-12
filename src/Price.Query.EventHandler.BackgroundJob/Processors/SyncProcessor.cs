using System.Threading.Tasks;
using AElf.AElfNode.EventHandler.BackgroundJob;
using AElf.AElfNode.EventHandler.BackgroundJob.EventProcessor;
using Gandalf.Contracts.Swap;
using Microsoft.Extensions.Logging;
using Price.Query.EventHandler.BackgroundJob.Options;
using Price.Query.EventHandler.BackgroundJob.Services;

namespace Price.Query.EventHandler.BackgroundJob.Processors
{
    public class SyncProcessor : AElfEventProcessorBase<Sync>
    {
        private readonly ILogger<SyncProcessor> _logger;
        private readonly IQueryPriceService _queryPriceService;

        public SyncProcessor(ILogger<SyncProcessor> logger, IQueryPriceService queryPriceService)
        {
            _logger = logger;
            _queryPriceService = queryPriceService;
        }

        protected override async Task HandleEventAsync(Sync eventDetailsEto, EventContext txContext)
        {
            _logger.LogInformation($"Sync Trigger: {eventDetailsEto}");
            await _queryPriceService.QuerySwapTokenPrice(new[]
            {
                new TokenPair
                {
                    TokenSymbol = eventDetailsEto.SymbolA,
                    UnderlyingTokenSymbol = eventDetailsEto.SymbolB
                }
            });
        }
    }
}