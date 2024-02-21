using WSH_HomeAssignment.Domain.ExchangeRatesServices;

namespace WSH_HomeAssignment.Api.Background
{
    public class CurrentExchangeRatesRequester : BackgroundService
    {
        private readonly IServiceScopeFactory serviceScopeFactory;
        private readonly ILogger<CurrentExchangeRatesRequester> logger;
        private readonly TimeSpan interval = TimeSpan.FromHours(6);
        private PeriodicTimer? timer;
        public CurrentExchangeRatesRequester(IServiceScopeFactory serviceScopeFactory,ILogger<CurrentExchangeRatesRequester> logger)
        {
            this.serviceScopeFactory = serviceScopeFactory;
            this.logger = logger;
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            timer = new PeriodicTimer(interval);
            return base.StartAsync(cancellationToken);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            do
            {
                try
                {
                    using (var scope = serviceScopeFactory.CreateScope())
                    {
                        var service = scope.ServiceProvider.GetRequiredService<ICachedExchangeRatesService>();
                        await service.RefreshAsync(stoppingToken);
                    }
                }
                catch(Exception ex)
                {
                    logger.LogError(new EventId(1),ex,ex.Message);
                }
              

            } while (!stoppingToken.IsCancellationRequested && await timer!.WaitForNextTickAsync(stoppingToken));
        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            timer?.Dispose();
            return base.StopAsync(cancellationToken);
        }
    }
}