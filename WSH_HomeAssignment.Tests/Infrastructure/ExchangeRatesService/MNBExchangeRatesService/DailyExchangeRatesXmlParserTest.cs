using WSH_HomeAssignment.Infrastructure.ExchangeRatesService;

namespace WSH_HomeAssignment.Tests.Infrastructure.ExchangeRatesService.MNBExchangeRatesService
{
    public class DailyExchangeRatesXmlParserTest
    {
        [Fact]
        public void Parse()
        {
            var parser = new DailyExchangeRatesXmlParser();
            var xml = TestFile.ReadAllText("test.xml");

            var exchangeRates = parser.Parse(xml);

            Assert.NotNull(exchangeRates);
            Assert.Equal(new DateOnly(2024, 02, 12), exchangeRates.Date);
            Assert.True(exchangeRates.ContainsKey("AUD"));
            Assert.Equal(234.55000, exchangeRates["AUD"].Value);
            Assert.Equal(1, exchangeRates["AUD"].Unit);
            Assert.True(exchangeRates.ContainsKey("BGN"));
            Assert.Equal(198.19000, exchangeRates["BGN"].Value);
            Assert.Equal(1, exchangeRates["BGN"].Unit);
            Assert.Equal(33, exchangeRates.Count);
        }
    }
}