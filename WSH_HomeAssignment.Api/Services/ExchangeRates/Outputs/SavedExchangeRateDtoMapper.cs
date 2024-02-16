using WSH_HomeAssignment.Domain.Entities;

namespace WSH_HomeAssignment.Api.Services.ExchangeRates.Outputs
{
    public static class SavedExchangeRateDtoMapper
    {
        public static SavedExchangeRateDto ToDto(this SavedExchangeRate saved)
        {
            return new SavedExchangeRateDto()
            {

                Currency = saved.ExchangeRate.Currency,
                Date = saved.ExchangeRate.Date,
                Unit = saved.ExchangeRate.Unit,
                Value = saved.ExchangeRate.Value,
                Note = saved.Note
            };
        }
    }
}
