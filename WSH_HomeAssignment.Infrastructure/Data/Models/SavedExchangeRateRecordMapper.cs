using WSH_HomeAssignment.Domain.Entities;

namespace WSH_HomeAssignment.Infrastructure.Data.Models
{
    internal static class SavedExchangeRateRecordMapper
    {
        internal static SavedExchangeRateRecord ToRecord(this SavedExchangeRate saved)
        {
            return new SavedExchangeRateRecord()
            {
                Date = saved.ExchangeRate.Date.ToDateTime(),
                Currency = saved.ExchangeRate.Currency,
                Note = saved.Note,
                UserId = saved.UserId
            };
        }
        internal static SavedExchangeRate ToDomainModel(this SavedExchangeRateRecord saved)
        {
            return new SavedExchangeRate(saved.ExchangeRate?.ToDomainModel()!, saved.UserId).SetNote(saved.Note);
        }
    }
}
