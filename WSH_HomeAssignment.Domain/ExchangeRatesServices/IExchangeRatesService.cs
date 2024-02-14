using WSH_HomeAssignment.Domain.Entities;

namespace WSH_HomeAssignment.Domain.ExchangeServices
{
    public interface IExchangeRatesService
    {
        Task<DailyExchangeRates> GetCurrentExchangeRatesAsync(CancellationToken cancellationToken=default);
    }
    public interface IExternalExchangeRatesService:IExchangeRatesService
    {
        string Source { get; }
    }
    public interface ICachedExchangeRatesService:IExchangeRatesService
    {
        Task RefreshAsync(CancellationToken cancellationToken = default);
    }


}
