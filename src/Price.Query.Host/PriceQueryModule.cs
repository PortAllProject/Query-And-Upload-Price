using AElf.AElfNode.EventHandler;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Price.Query.EventHandler.BackgroundJob;
using Volo.Abp.Autofac;
using Volo.Abp.EventBus.RabbitMq;
using Volo.Abp.Modularity;

namespace Price.Host
{

    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(TokenPriceUpdateEventHandlerBackgroundJobModule),
        typeof(AElfNodeEventHandlerModule),
        typeof(AbpEventBusRabbitMqModule)
    )]
    public class PriceQueryModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            var hostEnvironment = context.Services.GetSingletonInstance<IHostEnvironment>();

            context.Services.AddHostedService<PriceQueryHostedService>();
        }
    }
}
