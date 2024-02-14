using WSH_HomeAssignment.Domain.Exceptions;

namespace WSH_HomeAssignment.Domain.Entities
{
    public class ExchangeRate
    {
        public string Currency { get; }
        public int Unit { get; }
        public double Value { get; }
        public ExchangeRate(string currency, int unit, double value)
        {
            InvalidEntityException.CheckNullOrWhiteSpace(currency);
            InvalidEntityException.CheckMaxLength(currency, DomainConstants.CurrencyMaxLength);
            InvalidEntityException.CheckMin(unit,DomainConstants.ValueMin);
            InvalidEntityException.CheckMin(value,DomainConstants.UnitMin);

            Currency = currency;
            Unit = unit;
            Value = value;
        }
    }
}
