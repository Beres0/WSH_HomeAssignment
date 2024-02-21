using WSH_HomeAssignment.Domain;
using WSH_HomeAssignment.Domain.Entities;
using WSH_HomeAssignment.Domain.ExchangeRatesServices;
using WSH_HomeAssignment.Domain.Repositories;

namespace WSH_HomeAssignment.Infrastructure.ExchangeRatesServices
{
    public class CachedExchangeRatesService : ICachedExchangeRatesService
    {
        private static DailyExchangeRateCollection? cached;

        private readonly IDailyExchangeRateRepository repository;
        private readonly IExternalExchangeRatesService external;

        public CachedExchangeRatesService(IDailyExchangeRateRepository repository, IExternalExchangeRatesService external)
        {
            this.repository = repository;
            this.external = external;
        }

        public Task<DailyExchangeRateCollection> GetCurrentExchangeRatesAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(cached)!;
        }

        public async Task RefreshAsync(CancellationToken cancellationToken = default)
        {
            var last = await repository.FindLastAsync(cancellationToken);

            var requested = await external.GetCurrentExchangeRatesAsync(cancellationToken);
            if (last is null || last.Date < requested.Date)
            {
                await repository.CreateAsync(requested, cancellationToken);
                await repository.SaveChangesAsync(cancellationToken);
                cached = requested;
            }
            else
            {
                cached = last;
            }
        }
    }
}