using WSH_HomeAssignment.Domain.Entities;

namespace WSH_HomeAssignment.Domain.Repositories
{
    public interface ISavedExchangeRateRepository
    {
        Task<SavedExchangeRate> CreateAsync(SavedExchangeRate saved, CancellationToken cancellationToken = default);
        Task DeleteAsync(DateOnly date, string currency, string userId, CancellationToken cancellationToken = default);
        Task<SavedExchangeRate?> FindAsync(DateOnly date, string currency, string userId, CancellationToken cancellationToken = default);
        Task<SavedExchangeRate> GetAsync(DateOnly date, string currency, string userId, CancellationToken cancellationToken = default);
        Task<SavedDailyExchangeRateCollection> GetAsync(DateOnly date, string userId, CancellationToken cancellationToken = default);
        Task<IPagedResult<SavedExchangeRate>> GetListAsync(string userId, IPaginationArgs args, CancellationToken cancellationToken = default);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<SavedExchangeRate> UpdateAsync(SavedExchangeRate saved, CancellationToken cancellationToken = default);
    }
}
