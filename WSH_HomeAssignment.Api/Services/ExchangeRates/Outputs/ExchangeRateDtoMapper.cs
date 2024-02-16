using WSH_HomeAssignment.Domain.Entities;

namespace WSH_HomeAssignment.Api.Services.ExchangeRates.Outputs
{
    public static class ExchangeRateDtoMapper
    {
        public static ExchangeRateDto ToDto(this ExchangeRate exchangeRate)
        {
            return new ExchangeRateDto()
            {
                Value = exchangeRate.Value,
                Currency = exchangeRate.Currency,
                Unit = exchangeRate.Unit
            };
        }

    }
}
