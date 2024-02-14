using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WSH_HomeAssignment.Domain.Entities;

namespace WSH_HomeAssignment.Infrastructure.ExchangeRatesService
{
    public class DailyExchangeRatesXmlParser
    {
        public virtual DailyExchangeRates Parse(string xml)
        {
            XDocument doc = XDocument.Parse(xml);
            var dateString = doc.Descendants("Day").First().Attribute("date")!.Value;
            var date=DateTime.ParseExact(dateString,
                                         "yyyy-MM-dd",
                                         CultureInfo.CurrentCulture);

            var exchangeRates = new Dictionary<string,ExchangeRate>();
            foreach (var rateNode in doc.Descendants("Rate"))
            {
                var currency = rateNode.Attribute("curr")!.Value;
                var unit =int.Parse(rateNode.Attribute("unit")!.Value);
                var value=double.Parse(rateNode.Value);
                exchangeRates.Add(currency, new ExchangeRate(currency, unit, value));
            }

            return new DailyExchangeRates(date, exchangeRates);
        }
    }
}
