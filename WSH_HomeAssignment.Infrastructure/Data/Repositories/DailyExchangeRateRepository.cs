using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSH_HomeAssignment.Domain.Entities;
using WSH_HomeAssignment.Domain.Repositories;
using WSH_HomeAssignment.Infrastructure.Data.Models;
using WSH_HomeAssignment.Domain.Extensions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WSH_HomeAssignment.Infrastructure.Data.Repositories
{


    public class DailyExchangeRateRepository : IDailyExchangeRateRepository
    {
        private readonly ExchangeRateDbContext context;

        public DailyExchangeRateRepository(ExchangeRateDbContext context)
        {
            this.context = context;
        }
        public async Task<DailyExchangeRates> CreateAsync(DailyExchangeRates exchangeRates, CancellationToken cancellationToken = default)
        {
            await context.ExchangeRates.AddRangeAsync(exchangeRates.Values
                .Select(r => new ExchangeRateRecord()
                {
                    Date = exchangeRates.Id,
                    Currency = r.Currency,
                    Unit = r.Unit,
                    Value = r.Value
                }), cancellationToken);
            return exchangeRates;
        }

        public async Task<bool> DeleteAsync(DateTime date, CancellationToken cancellationToken = default)
        {
            date = date.TrimTime();

            var result = context.ExchangeRates.OrderBy(r => r.Date)
                                        .Where(r => r.Date == date);

            if (!await result.AnyAsync(cancellationToken))
            {
                return false;
            }

            await result.ExecuteDeleteAsync(cancellationToken);
            return true;
        }
        private DailyExchangeRates CreateFrom(DateTime date,IQueryable<ExchangeRateRecord> records)
        {
            return new DailyExchangeRates(date, records.ToDictionary(r => r.Currency, r => r.ToExchangeRate()));
        }
        public async Task<DailyExchangeRates?> GetAsync(DateTime date, CancellationToken cancellationToken = default)
        {
            date = date.TrimTime();
            var result = context.ExchangeRates.OrderBy(r => r.Date).Where(r => r.Date == date);
            if (!await result.AnyAsync(cancellationToken))
            {
                return null;
            }
            return CreateFrom(date, result);
        }

        public async Task<DailyExchangeRates?> GetLastAsync(CancellationToken cancellationToken = default)
        {
            var last = await context.ExchangeRates.MaxAsync(r => r.Date, cancellationToken);
            var result = context.ExchangeRates.OrderByDescending(r => r.Date).Where(r => r.Date == last.Date);
           if (!await result.AnyAsync(cancellationToken))
            {
                return null;
            }
            return CreateFrom(last.Date, result);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
