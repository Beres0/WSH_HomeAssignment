using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WSH_HomeAssignment.Domain.Exceptions;

namespace WSH_HomeAssignment.Domain.Entities
{
    public class DailyExchangeRates : IEntity<DateTime>, IReadOnlyDictionary<string, ExchangeRate>
    {
        public DateTime Id { get; }

        public IEnumerable<string> Keys => _exchangeRates.Keys;

        public IEnumerable<ExchangeRate> Values =>_exchangeRates.Values;

        public int Count => _exchangeRates.Count;

        public ExchangeRate this[string key] => _exchangeRates[key];
        private readonly IReadOnlyDictionary<string, ExchangeRate> _exchangeRates;
        public DailyExchangeRates(DateTime date,IEnumerable<KeyValuePair<string,ExchangeRate>> exchangeRates)
        {
            InvalidEntityException.CheckMin(date, DomainConstants.DateMin);

            Id = date;
            _exchangeRates=exchangeRates.ToDictionary(kv=>kv.Key,kv=>kv.Value);
        }
        public bool ContainsKey(string key)
        {
            return _exchangeRates.ContainsKey(key);
        }
    
        public bool TryGetValue(string key, [MaybeNullWhen(false)] out ExchangeRate value)
        {
            return _exchangeRates.TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public object[] GetKey()
        {
            return new object[] { Id };
        }

        public IEnumerator<KeyValuePair<string, ExchangeRate>> GetEnumerator()
        {
            return _exchangeRates.GetEnumerator();
        }
    }
}
