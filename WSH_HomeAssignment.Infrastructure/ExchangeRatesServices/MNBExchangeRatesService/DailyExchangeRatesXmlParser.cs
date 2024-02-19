using System.Globalization;
using System.Xml.Linq;
using WSH_HomeAssignment.Domain.Entities;

namespace WSH_HomeAssignment.Infrastructure.ExchangeRatesService
{
    public class DailyExchangeRatesXmlParser
    {
        public virtual DailyExchangeRateCollection Parse(string xml)
        {
            XDocument doc = XDocument.Parse(xml);
            var dateString = doc.Descendants("Day").First().Attribute("date")!.Value;
            var date = DateOnly.ParseExact(dateString,
                                         "yyyy-MM-dd",
                                         CultureInfo.CurrentCulture);

            var exchangeRates = doc.Descendants("Rate").Select(r =>
            {
                var currency = r.Attribute("curr")!.Value;
                var unit = int.Parse(r.Attribute("unit")!.Value);
                var value = double.Parse(r.Value);
                return new ExchangeRate(currency, unit, value);
            });
            return new DailyExchangeRateCollection(date, exchangeRates);
        }
    }
}