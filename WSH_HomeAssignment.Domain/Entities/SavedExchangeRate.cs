using WSH_HomeAssignment.Domain.Exceptions;

namespace WSH_HomeAssignment.Domain.Entities
{
    public class SavedExchangeRate:IEntity
    {
        public DateTime Date { get; }
        public string Currency { get; }
        public int Unit { get; }
        public double Value { get; }
        public string? Note { get; private set; } 

        public SavedExchangeRate(DateTime date, string currency, int unit, double value)
        {
            InvalidEntityException.CheckMin(date, DomainConstants.DateMin);
            InvalidEntityException.CheckNullOrWhiteSpace(currency);
            InvalidEntityException.CheckMaxLength(currency, DomainConstants.CurrencyMaxLength);
            InvalidEntityException.CheckMin(unit, DomainConstants.ValueMin);
            InvalidEntityException.CheckMin(value, DomainConstants.UnitMin);

            Date = date;
            Currency = currency;
            Unit = unit;
            Value = value;
        }
        public SavedExchangeRate SetNote(string? note)
        {
            InvalidEntityException.CheckMaxLength(note, 100);
            Note = note;
            return this;
        }

        public object[] GetKey()
        {
            return new object[] { Date, Currency };
        }

      

    }
}
