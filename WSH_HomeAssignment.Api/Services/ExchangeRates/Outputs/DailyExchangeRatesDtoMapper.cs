using WSH_HomeAssignment.Domain.Entities;

namespace WSH_HomeAssignment.Api.Services.ExchangeRates.Outputs
{
    internal static class DailyExchangeRatesDtoMapper
    {
        public static DailyExchangeRatesDto ToDto(this DailyExchangeRateCollection exchangeRates)
        {
            return new DailyExchangeRatesDto()
            {
                Date = exchangeRates.Date.ToDto(),
                ExchangeRates = exchangeRates.ToDictionary(r => r.Key, r => r.Value.ToDto())
            };
        }
    }
}