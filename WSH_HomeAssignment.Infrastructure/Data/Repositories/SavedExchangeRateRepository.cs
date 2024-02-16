using Microsoft.EntityFrameworkCore;
using System.Threading;
using WSH_HomeAssignment.Domain.Entities;
using WSH_HomeAssignment.Domain.Repositories;
using WSH_HomeAssignment.Infrastructure.Data.Models;

namespace WSH_HomeAssignment.Infrastructure.Data.Repositories
{

    public class SavedExchangeRateRepository : ISavedExchangeRateRepository
    {
        private readonly ExchangeRateDbContext context;

        public SavedExchangeRateRepository(ExchangeRateDbContext context)
        {
            this.context = context;
        }

        private async Task<SavedExchangeRateRecord?> FindRecordAsync(DateOnly date, string currency, string userId, CancellationToken cancellationToken = default)
        {
            var dateTime = date.ToDateTime();
            return await GetOrderedExchangeRates()
                    .Where(r => r.Date == dateTime && r.Currency == currency && r.UserId == userId)
                    .Include(r => r.ExchangeRate)
                    .FirstOrDefaultAsync(cancellationToken);
        }
        private async Task<SavedExchangeRateRecord?> FindRecordAsync(SavedExchangeRate saved, CancellationToken cancellationToken = default)
        {
            var result = await FindRecordAsync(saved.ExchangeRate.Date, saved.ExchangeRate.Currency, saved.UserId, cancellationToken);
            return result;
        }
        private IQueryable<SavedExchangeRateRecord> GetOrderedExchangeRates()
        {
            return context.SavedExchangeRates.OrderByDescending(r => r.Date)
                                          .ThenBy(r => r.Currency)
                                          .ThenBy(r => r.UserId);
        }
        public async Task<IPagedResult<SavedExchangeRate>> GetListAsync(string userId, IPaginationArgs args, CancellationToken cancellationToken = default)
        {
            return await new PagedResultBuilder<SavedExchangeRateRecord>(GetOrderedExchangeRates())
                                            .SetFilter(r => r.UserId == userId)
                                            .SetPaginationArgs(args)
                                            .SetIncludes(nameof(SavedExchangeRateRecord.ExchangeRate))
                                            .ToPagedResultAsync(r => r.ToDomainModel(), cancellationToken);
        }


        public async Task<SavedExchangeRate> GetAsync(DateOnly date, string currency, string userId, CancellationToken cancellationToken = default)
        {
            var result = await FindAsync(date, currency, userId, cancellationToken);
            EntityNotFoundException<SavedExchangeRate>.CheckResult(result, date, currency, userId);
            return result!;
        }
        public async Task<SavedExchangeRate?> FindAsync(DateOnly date, string currency, string userId, CancellationToken cancellationToken = default)
        {
            var result = await FindRecordAsync(date, currency, userId, cancellationToken);
            if (result is null)
            {
                return null;
            }
            return result.ToDomainModel();
        }

        public async Task<SavedExchangeRate> CreateAsync(SavedExchangeRate saved, CancellationToken cancellationToken = default)
        {
            var result = await FindRecordAsync(saved, cancellationToken);
            EntityAlreadyExistsException<SavedExchangeRate>.CheckResult(result, saved.GetKey());
            await context.SavedExchangeRates.AddAsync(saved.ToRecord(), cancellationToken);
            return saved;

        }

        public async Task<SavedExchangeRate> UpdateAsync(SavedExchangeRate saved, CancellationToken cancellationToken = default)
        {
            var result = await FindRecordAsync(saved, cancellationToken);
            EntityNotFoundException<SavedExchangeRate>.CheckResult(result, saved.GetKey());
            result!.Note = saved.Note;
            context.Update(result);
            return saved;
        }

        public async Task DeleteAsync(DateOnly date, string currency, string userId, CancellationToken cancellationToken = default)
        {
            var result = await FindRecordAsync(date, currency, userId, cancellationToken);
            EntityNotFoundException<SavedExchangeRate>.CheckResult(result, date, currency, userId);
            context.SavedExchangeRates.Remove(result!);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await context.SaveChangesAsync(cancellationToken);
        }

    }
}
