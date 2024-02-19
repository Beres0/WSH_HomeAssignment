using WSH_HomeAssignment.Domain.Repositories;

namespace WSH_HomeAssignment.Domain.Entities
{
    public class SavedDailyExchangeRateCollection : DailyExchangeRateCollection
    {
        public string UserId { get; }
        private readonly Dictionary<string, string?> notes;

        public SavedDailyExchangeRateCollection(DateOnly date, string userId, IEnumerable<SavedExchangeRate> exchangeRates) : base(date, exchangeRates.Select(e => e.ExchangeRate))
        {
            InvalidArgumentException.CheckNullOrWhiteSpace(userId);
            UserId = userId;
            notes = exchangeRates.ToDictionary(r => r.ExchangeRate.Currency, r => r.Note);
        }

        public IEnumerable<KeyValuePair<string, string?>> GetNotes()
        {
            return notes;
        }

        public string? GetNote(string currency)
        {
            if (!notes.TryGetValue(currency, out string? value))
            {
                EntityNotFoundException.Check<SavedExchangeRate>(null, Date, currency, UserId);
            }
            return value;
        }

        public override object[] GetKey()
        {
            return new object[]
            {
                    Date,UserId
            };
        }
    }
}