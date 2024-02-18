using WSH_HomeAssignment.Domain.Entities;

namespace WSH_HomeAssignment.Api.Services.ExchangeRates.Inputs
{
    public static class CreateUpdateSavedExchangeRateMapper
    {
        public static SavedExchangeRate ToDomainModel(this CreateUpdateSavedExchangeRateDto dto,DailyExchangeRate exchangeRate,string userId)
        {
            return new SavedExchangeRate(exchangeRate, userId).SetNote(dto.Note);
        }
    }
}
