using WSH_HomeAssignment.Domain.Entities;

namespace WSH_HomeAssignment.Api.Services.ExchangeRates.Outputs
{
    public static class DailyExchangeRateDtoMapper
    {
        public static DailyExchangeRateDto ToDto(this DailyExchangeRate exchangeRate)
        {
            return new DailyExchangeRateDto()
            {
                Date = exchangeRate.Date.ToDto(),
                Currency = exchangeRate.Currency,
                Unit = exchangeRate.Unit,
                Value = exchangeRate.Value
            };
        }
    }
}