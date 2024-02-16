namespace WSH_HomeAssignment.Domain.Entities
{
    public class ExchangeRate : IEntity
    {
        public string Currency { get; protected set; }
        public int Unit { get; protected set; }
        public double Value { get; protected set; }

        public ExchangeRate(string currency, int unit, double value)
        {
            InvalidArgumentException.CheckNullOrWhiteSpace(currency);
            InvalidArgumentException.CheckMaxLength(currency, DomainConstants.CurrencyMaxLength);
            InvalidArgumentException.CheckMin(unit, DomainConstants.ValueMin);
            InvalidArgumentException.CheckMin(value, DomainConstants.UnitMin);

            Currency = currency;
            Unit = unit;
            Value = value;
        }

        public virtual object[] GetKey()
        {
            return new object[] { Currency };
        }

    }

}
