using WSH_HomeAssignment.Api.Services.ExchangeRates.Outputs;

namespace WSH_HomeAssignment.Api.Services.Application
{
    public interface IExchangeRatesAppService
    {
        Task<DailyExchangeRatesDto> GetCurrentExchangeRatesAsync();
    }
}