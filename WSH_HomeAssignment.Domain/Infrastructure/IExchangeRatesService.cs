using WSH_HomeAssignment.Domain.Entities;
using WSH_HomeAssignment.Domain.Entities.WSH_HomeAssignment.Domain.Entities;

namespace WSH_HomeAssignment.Domain.Infrastructure
{
    public interface IExchangeRatesService
    {
        Task<DailyExchangeRateCollection> GetCurrentExchangeRatesAsync(CancellationToken cancellationToken = default);
    }
    public interface IExternalExchangeRatesService : IExchangeRatesService
    {
        string Source { get; }
    }
    public interface ICachedExchangeRatesService : IExchangeRatesService
    {
        Task RefreshAsync(CancellationToken cancellationToken = default);
    }


}
