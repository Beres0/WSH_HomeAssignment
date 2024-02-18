using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSH_HomeAssignment.Domain.Entities;
using WSH_HomeAssignment.Domain.Repositories;
using WSH_HomeAssignment.Infrastructure.Data.Models;

namespace WSH_HomeAssignment.Infrastructure.Data.Repositories
{
    public class DailyExchangeRateRepository : IDailyExchangeRateRepository
    {
        private readonly ExchangeRateDbContext context;
        public DailyExchangeRateRepository(ExchangeRateDbContext context)
        {
            this.context = context;
        }

        private IQueryable<ExchangeRateRecord> GetOrderedExchangeRates()
        {
            return context.ExchangeRates.OrderByDescending(r => r.Date).ThenBy(r => r.Currency);
        }

        private async Task<ExchangeRateRecord?> FindRecordAsync(DateOnly date, string currency, CancellationToken cancellationToken)
        {
            var dateTime = date.ToDateTime();
            return await GetOrderedExchangeRates().FirstOrDefaultAsync(r => r.Date == dateTime && r.Currency == currency, cancellationToken);
        }

        public async Task<DailyExchangeRateCollection> CreateAsync(DailyExchangeRateCollection exchangeRates, CancellationToken cancellationToken = default)
        {
            var result = await FindAsync(exchangeRates.Date, cancellationToken);
            if (result is not null)
            {
                EntityAlreadyExistsException.Check<DailyExchangeRateCollection>(result, exchangeRates.Date);
            }
            await context.ExchangeRates.AddRangeAsync(exchangeRates.Select(r => r.Value.ToRecord(exchangeRates.Date)));
            return exchangeRates;
        }
        public async Task DeleteAsync(DateOnly date, CancellationToken cancellationToken = default)
        {
            var dateTime = date.ToDateTime();
            var result = GetOrderedExchangeRates().Where(r => r.Date == dateTime);
            if (!await result.AnyAsync(cancellationToken))
            {
                EntityNotFoundException.Check<DailyExchangeRateCollection>(null, date);
            }
            await result.ExecuteDeleteAsync(cancellationToken);
        }

        public async Task<DailyExchangeRate?> FindAsync(DateOnly date, string currency, CancellationToken cancellationToken = default)
        {
            return (await FindRecordAsync(date, currency, cancellationToken))?.ToDomainModel() ?? null;
        }
        public async Task<DailyExchangeRateCollection?> FindAsync(DateOnly date, CancellationToken cancellationToken = default)
        {
            var dateTime = date.ToDateTime();
            var result = GetOrderedExchangeRates().Where(r => r.Date == dateTime);
            if (!await result.AnyAsync(cancellationToken))
            {
                return null;
            }
            var exchangeRates = await result.Select(r => r.ToDomainModel()).ToListAsync(cancellationToken);
            return new DailyExchangeRateCollection(date, exchangeRates);
        }

        public async Task<DailyExchangeRate> GetAsync(DateOnly date, string currency, CancellationToken cancellationToken = default)
        {
            var result = await FindAsync(date, currency, cancellationToken);
            EntityNotFoundException.Check<DailyExchangeRate>(result, date, currency);
            return result!;
        }
        public async Task<DailyExchangeRateCollection> GetAsync(DateOnly date, CancellationToken cancellationToken = default)
        {
            var result = await FindAsync(date, cancellationToken);
            EntityNotFoundException.Check<DailyExchangeRateCollection>(result, date);
            return result!;
        }
        public async Task<DailyExchangeRateCollection?> FindLastAsync(CancellationToken cancellationToken = default)
        {
            var lastDate =await FindLastDateAsync(cancellationToken);
            if(lastDate is null)
            {
                return null;
            }
            return await GetAsync(lastDate.Value, cancellationToken);
        }
       
        public async Task<IPagedResult<DailyExchangeRate>> GetListAsync(string currency, IPaginationArgs args, CancellationToken cancellationToken = default)
        {
            return await new PagedResultBuilder<ExchangeRateRecord>(GetOrderedExchangeRates())
                      .SetFilter(r => r.Currency == currency)
                      .SetPaginationArgs(args)
                      .ToPagedResultAsync(r => r.ToDomainModel(), cancellationToken);
        }


        public Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return context.SaveChangesAsync(cancellationToken);
        }

        public async Task<DateOnly?> FindLastDateAsync(CancellationToken cancellationToken = default)
        {
            var hasData = await GetOrderedExchangeRates().AnyAsync(cancellationToken);
            if (!hasData)
            {
                return null;
            }
           return (await GetOrderedExchangeRates().MaxAsync(r => r.Date, cancellationToken)).ToDateOnly();
        }
    }

}
