using WSH_HomeAssignment.Domain.Entities;

namespace WSH_HomeAssignment.Domain.Repositories
{
    public interface IDailyExchangeRateRepository
    {
        Task<DailyExchangeRateCollection> CreateAsync(DailyExchangeRateCollection exchangeRates, CancellationToken cancellationToken = default);

        Task DeleteAsync(DateOnly date, CancellationToken cancellationToken = default);

        Task<DailyExchangeRateCollection?> FindAsync(DateOnly date, CancellationToken cancellationToken = default);

        Task<DailyExchangeRate?> FindAsync(DateOnly date, string currency, CancellationToken cancellationToken = default);

        Task<DailyExchangeRateCollection?> FindLastAsync(CancellationToken cancellationToken = default);

        Task<DateOnly?> FindLastDateAsync(CancellationToken cancellationToken = default);

        Task<DailyExchangeRateCollection> GetAsync(DateOnly date, CancellationToken cancellationToken = default);

        Task<DailyExchangeRate> GetAsync(DateOnly date, string currency, CancellationToken cancellationToken = default);

        Task<IPagedResult<DailyExchangeRate>> GetListAsync(string currency, IPaginationArgs args, CancellationToken cancellationToken = default);

        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}