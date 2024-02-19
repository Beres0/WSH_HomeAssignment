namespace WSH_HomeAssignment.Domain.Entities
{
    public class SavedExchangeRate : IEntity
    {
        public string UserId { get; }
        public DailyExchangeRate ExchangeRate { get; }
        public string? Note { get; private set; }

        public SavedExchangeRate(DailyExchangeRate exchangeRate, string userId)
        {
            InvalidArgumentException.CheckNullOrWhiteSpace(userId);
            InvalidArgumentException.CheckNull(exchangeRate);
            UserId = userId;
            ExchangeRate = exchangeRate;
        }

        public SavedExchangeRate SetNote(string? note)
        {
            InvalidArgumentException.CheckMaxLength(note, 100);
            Note = note;
            return this;
        }

        public object[] GetKey()
        {
            return new object[] { ExchangeRate.Date, ExchangeRate.Currency, UserId };
        }
    }
}