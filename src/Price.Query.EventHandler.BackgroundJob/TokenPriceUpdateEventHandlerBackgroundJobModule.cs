using AElf.AElfNode.EventHandler.BackgroundJob;
using Microsoft.Extensions.DependencyInjection;
using Price.Query.AElfWeb;
using Price.Query.EventHandler.BackgroundJob.Options;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Price.Query.EventHandler.BackgroundJob
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(PriceQueryAElfOracleWebModule),
        typeof(AElfEventHandlerBackgroundJobModule))]
    public class TokenPriceUpdateEventHandlerBackgroundJobModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            Configure<PriceQueryOptions>(configuration.GetSection("PriceQuery"));
            Configure<ExchangeQueryOptions>(configuration.GetSection("ExchangeQuery"));
            Configure<TokenSwapQueryOptions>(configuration.GetSection("TokenSwapQuery"));
        }
    }
}