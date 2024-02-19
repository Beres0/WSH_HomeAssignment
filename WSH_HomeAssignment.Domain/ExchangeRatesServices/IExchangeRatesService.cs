using WSH_HomeAssignment.Domain.Entities;

namespace WSH_HomeAssignment.Domain.ExchangeRatesServices
{
    public interface IExchangeRatesService
    {
        Task<DailyExchangeRateCollection> GetCurrentExchangeRatesAsync(CancellationToken cancellationToken = default);
    }
}