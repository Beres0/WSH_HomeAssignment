using System.ComponentModel;
using WSH_HomeAssignment.Domain.Infrastructure;
using WSH_HomeAssignment.Domain.Repositories;

namespace WSH_HomeAssignment.Api.Background
{
    public class CurrentExchangeRatesRequester : BackgroundService
    {
        private readonly IServiceScopeFactory serviceScopeFactory;

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

                await Task.Delay(TimeSpan.FromHours(6),stoppingToken);
            } while (!stoppingToken.IsCancellationRequested);
        }
    }
}
