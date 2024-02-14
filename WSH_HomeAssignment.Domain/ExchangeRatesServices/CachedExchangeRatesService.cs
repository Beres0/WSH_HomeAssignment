using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSH_HomeAssignment.Domain.Entities;
using WSH_HomeAssignment.Domain.Exceptions;
using WSH_HomeAssignment.Domain.ExchangeServices;
using WSH_HomeAssignment.Domain.Repositories;

namespace WSH_HomeAssignment.Domain.ExchangeRatesServices
{
    public class CachedExchangeRatesService : ICachedExchangeRatesService
    {
        private static DailyExchangeRates? cached;
        private static readonly SemaphoreSlim slim = new SemaphoreSlim(1, 1);

        private readonly IDailyExchangeRateRepository repository;
        private readonly IExternalExchangeRatesService external;

        public CachedExchangeRatesService(IDailyExchangeRateRepository repository, IExternalExchangeRatesService external) {
            this.repository = repository;
            this.external = external;
        }

        public Task<DailyExchangeRates> GetCurrentExchangeRatesAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(cached)!;
        }

        public async Task RefreshAsync(CancellationToken cancellationToken = default)
        {
            await slim.WaitAsync(cancellationToken);
            var last = await repository.GetLastAsync(cancellationToken);
            try
            {
                cached = await external.GetCurrentExchangeRatesAsync(cancellationToken);
                if(last is null || last.Id != cached.Id)
                {
                    await repository.CreateAsync(cached, cancellationToken);
                    await repository.SaveChangesAsync(cancellationToken);
                }
            }
            catch (InfrastructureException)
            {
                cached = last;
            }
            finally
            {
                slim.Release();
            }
        }
    }
}
