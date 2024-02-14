using Microsoft.EntityFrameworkCore;
using WSH_HomeAssignment.Domain.Entities;
using WSH_HomeAssignment.Domain.Exceptions;
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

        public async Task<SavedExchangeRate> CreateAsync(DateTime date, string currency, string userId, string? note = null, CancellationToken cancellationToken = default)
        {
            var rate = await context.ExchangeRates
                                           .OrderBy(r => r.Date)
                                           .ThenBy(r => r.Currency)
                                           .FirstOrDefaultAsync(cancellationToken);

            RepositoryException.CheckResult<ExchangeRate>(rate, date, currency, userId);

            await context.SavedExchangeRates.AddAsync(new SavedExchangeRateRecord()
            {
                Date = date,
                Currency = currency,
                Note = note,
                UserId = userId,
            }, cancellationToken);



            return new SavedExchangeRate(date, currency, rate!.Unit, rate!.Value)
                                        .SetNote(note);
        }
        private async Task<SavedExchangeRateRecord?> GetRecordFirstOrDefaultAsync(DateTime date, string currency, string userId, CancellationToken cancellationToken = default)
        {
            return await GetOrderedExchangeRates()
                    .Where(r => r.Date == date && r.Currency == currency && r.UserId == userId)
                    .FirstOrDefaultAsync(cancellationToken);
        }
        private IQueryable<SavedExchangeRateRecord> GetOrderedExchangeRates()
        {
            return context.SavedExchangeRates.OrderBy(r => r.Date)
                                          .ThenBy(r => r.Currency)
                                          .ThenBy(r => r.UserId);
        }

        public async Task<bool> DeleteAsync(DateTime date, string currency, string userId, CancellationToken cancellationToken = default)
        {
            var result = await GetRecordFirstOrDefaultAsync(date, currency, userId, cancellationToken);
            if (result is null) return false;
            context.SavedExchangeRates.Remove(result);
            return true;
        }

        public async Task<SavedExchangeRate?> GetAsync(DateTime date, string currency, string userId, CancellationToken cancellationToken = default)
        {
            var result = await GetOrderedExchangeRates()
                                      .Where(r => r.Date == date && r.Currency == currency && r.UserId == userId)
                                      .Include(r => r.ExchangeRate)
                                      .FirstOrDefaultAsync(cancellationToken);
            if (result is null)
            {
                return null;
            }
            return new SavedExchangeRate(result.Date,
                                         result.Currency,
                                         result.ExchangeRate.Unit,
                                         result.ExchangeRate.Value)
                                        .SetNote(result.Note);

        }

        public async Task<IPagedResult<SavedExchangeRate>> GetListAsync(string userId, IPaginationArgs args, CancellationToken cancellationToken = default)
        {
            var filtered = context.SavedExchangeRates.OrderBy(r => r.UserId)
                                                           .Where(r => r.UserId == userId);


            var totalCount = await filtered.CountAsync(cancellationToken);
            if (totalCount == 0)
            {
                return new PagedResult<SavedExchangeRate>(totalCount, args, new List<SavedExchangeRate>());

            }
            var result = await filtered.OrderByDescending(r => r.Date)
                               .Skip(args.Skip)
                               .Take(args.Take)
                               .Include(r => r.ExchangeRate)
                               .Select(r => new SavedExchangeRate(r.Date, r.Currency, r.ExchangeRate.Unit, r.ExchangeRate.Value))
                               .ToListAsync(cancellationToken);

            return new PagedResult<SavedExchangeRate>(totalCount, args, result);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task<SavedExchangeRate> UpdateAsync(SavedExchangeRate savedExchangeRate, string userId, CancellationToken cancellationToken = default)
        {
            var result = await GetRecordFirstOrDefaultAsync(savedExchangeRate.Date,
                                                      savedExchangeRate.Currency,
                                                      userId,
                                                      cancellationToken);

            RepositoryException.CheckResult<SavedExchangeRateRecord>(result,
                                                                     savedExchangeRate.Date,
                                                                     savedExchangeRate.Currency,
                                                                     userId);
            result!.Note = savedExchangeRate.Note;
            context.Update(result);
            return savedExchangeRate;
        }
    }
}
