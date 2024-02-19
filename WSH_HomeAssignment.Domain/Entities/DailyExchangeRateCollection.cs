using System.Collections;
using System.Diagnostics.CodeAnalysis;
using WSH_HomeAssignment.Domain.Repositories;

namespace WSH_HomeAssignment.Domain.Entities
{
    public class DailyExchangeRateCollection : IEntity, IReadOnlyDictionary<string, ExchangeRate>
    {
        public DateOnly Date { get; }

        public IEnumerable<string> Keys => exchangeRates.Keys;

        public IEnumerable<ExchangeRate> Values => exchangeRates.Values;

        public int Count => exchangeRates.Count;

        public ExchangeRate this[string currency]
        {
            get
            {
                if (!exchangeRates.TryGetValue(currency, out ExchangeRate? value))
                {
                    EntityNotFoundException.Check<ExchangeRate>(value, Date, currency);
                }
                return value!;
            }
        }

        private readonly IReadOnlyDictionary<string, ExchangeRate> exchangeRates;

        public DailyExchangeRateCollection(DateOnly date, IEnumerable<ExchangeRate> exchangeRates)
        {
            InvalidArgumentException.CheckMin(date, DomainConstants.DateMin);

            Date = date;
            this.exchangeRates = exchangeRates.ToDictionary(r => r.Currency, r => r);
        }

        public bool ContainsKey(string currency)
        {
            return exchangeRates.ContainsKey(currency);
        }

        public bool TryGetValue(string currency, [MaybeNullWhen(false)] out ExchangeRate value)
        {
            return exchangeRates.TryGetValue(currency, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public virtual object[] GetKey()
        {
            return new object[] { Date };
        }

        public IEnumerator<KeyValuePair<string, ExchangeRate>> GetEnumerator()
        {
            return exchangeRates.GetEnumerator();
        }
    }
}