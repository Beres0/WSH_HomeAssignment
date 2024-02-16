﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSH_HomeAssignment.Domain.Entities;
using WSH_HomeAssignment.Domain.Entities.WSH_HomeAssignment.Domain.Entities;
using WSH_HomeAssignment.Domain.Infrastructure;
using WSH_HomeAssignment.Domain.Repositories;

namespace WSH_HomeAssignment.Infrastructure.ExchangeRatesServices
{
    public class CachedExchangeRatesService : ICachedExchangeRatesService
    {
        private static DailyExchangeRateCollection? cached;

        private readonly IDailyExchangeRateRepository repository;
        private readonly IExternalExchangeRatesService external;

        public CachedExchangeRatesService(IDailyExchangeRateRepository repository, IExternalExchangeRatesService external) {
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
            try
            {
                var requested = await external.GetCurrentExchangeRatesAsync(cancellationToken);
                if(last is null || last.Date< requested.Date)
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
            catch (InfrastructureException)
            {
                cached = last;
            }
        }
    }
}