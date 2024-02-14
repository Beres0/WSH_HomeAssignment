using WSH_HomeAssignment.Domain.Entities;

namespace WSH_HomeAssignment.Domain.Repositories
{
    public interface ISavedExchangeRateRepository
    {
        Task<SavedExchangeRate> CreateAsync(DateTime date, string currency, string userId, string? note = null, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(DateTime date, string currency, string userId, CancellationToken cancellationToken = default);
        Task<SavedExchangeRate?> GetAsync(DateTime date, string currency, string userId, CancellationToken cancellationToken = default);
        Task<IPagedResult<SavedExchangeRate>> GetListAsync(string userId, IPaginationArgs args, CancellationToken cancellationToken = default);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<SavedExchangeRate> UpdateAsync(SavedExchangeRate savedExchangeRate, string userId, CancellationToken cancellationToken = default);
    }
  
}
