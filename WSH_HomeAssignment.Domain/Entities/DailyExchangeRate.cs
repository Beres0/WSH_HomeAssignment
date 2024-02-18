namespace WSH_HomeAssignment.Domain.Entities
{

    public class DailyExchangeRate:ExchangeRate
    {
        public DailyExchangeRate(DateOnly date,string currency, int unit, double value) : base(currency, unit, value)
        {
            InvalidArgumentException.CheckMin(date, DomainConstants.DateMin);

            Date = date;
        }

        public DateOnly Date { get; }
        public override object[] GetKey()
        {
            return new object[] {Date, Currency };
        }
    }

}
