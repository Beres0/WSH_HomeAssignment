using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSH_HomeAssignment.Domain.Entities
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;

    namespace WSH_HomeAssignment.Domain.Entities
    {
        public class DailyExchangeRateCollection : IEntity, IReadOnlyDictionary<string, ExchangeRate>
        {
            public DateOnly Date { get; }

            public IEnumerable<string> Keys => exchangeRates.Keys;

            public IEnumerable<ExchangeRate> Values => exchangeRates.Values;

            public int Count => exchangeRates.Count;

            public ExchangeRate this[string key] => exchangeRates[key];
            private readonly IReadOnlyDictionary<string, ExchangeRate> exchangeRates;
            public DailyExchangeRateCollection(DateOnly date, IEnumerable<ExchangeRate> exchangeRates)
            {
                InvalidArgumentException.CheckMin(date, DomainConstants.DateMin);

                 Date = date;
                this.exchangeRates = exchangeRates.ToDictionary(r => r.Currency, r => r);
            }
            public bool ContainsKey(string key)
            {
                return exchangeRates.ContainsKey(key);
            }

            public bool TryGetValue(string key, [MaybeNullWhen(false)] out ExchangeRate value)
            {
                return exchangeRates.TryGetValue(key, out value);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public object[] GetKey()
            {
                return new object[] { Date };
            }

            public IEnumerator<KeyValuePair<string, ExchangeRate>> GetEnumerator()
            {
                return exchangeRates.GetEnumerator();
            }
        }
    }
}
