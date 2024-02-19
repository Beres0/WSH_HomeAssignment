using WSH_HomeAssignment.Domain.Entities;

namespace WSH_HomeAssignment.Infrastructure.Data.Models
{
    internal static class ExchangeRateRecordMapper
    {
        internal static ExchangeRateRecord ToRecord(this ExchangeRate exchangeRate, DateOnly date)
        {
            return new ExchangeRateRecord()
            {
                Currency = exchangeRate.Currency,
                Date = date.ToDateTime(),
                Value = exchangeRate.Value,
                Unit = exchangeRate.Unit
            };
        }

        internal static ExchangeRateRecord ToRecord(this DailyExchangeRate exchangeRate)
        {
            return new ExchangeRateRecord()
            {
                Currency = exchangeRate.Currency,
                Unit = exchangeRate.Unit,
                Value = exchangeRate.Value,
                Date = exchangeRate.Date.ToDateTime()
            };
        }

        internal static DailyExchangeRate ToDomainModel(this ExchangeRateRecord record)
        {
            return new DailyExchangeRate(record.Date.ToDateOnly(), record.Currency, record.Unit, record.Value);
        }
    }
}