using System.ComponentModel;
using WSH_HomeAssignment.Domain.ExchangeRatesServices;
using WSH_HomeAssignment.Domain.Repositories;

namespace WSH_HomeAssignment.Api.Background
{
    public class CurrentExchangeRatesRequester : BackgroundService
    {
        private readonly IServiceScopeFactory serviceScopeFactory;
        private readonly TimeSpan interval = TimeSpan.FromHours(6);
        public CurrentExchangeRatesRequester(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            do
            {
                using (var scope = serviceScopeFactory.CreateScope())
                {
                    var service=scope.ServiceProvider.GetRequiredService<ICachedExchangeRatesService>();
                    await service.RefreshAsync(stoppingToken);
                }

                await Task.Delay(interval,stoppingToken);
            } while (!stoppingToken.IsCancellationRequested);
        }
    }
}
