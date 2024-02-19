using WSH_HomeAssignment.Domain;
using WSH_HomeAssignment.Domain.Entities;
using WSH_HomeAssignment.Domain.ExchangeRatesServices;
using www.mnb.hu.webservices;

namespace WSH_HomeAssignment.Infrastructure.ExchangeRatesService
{
    public class MNBExchangeRatesService : IExternalExchangeRatesService
    {
        private readonly DailyExchangeRatesXmlParser parser;
        private readonly MNBArfolyamServiceSoapClient client;

        public MNBExchangeRatesService(DailyExchangeRatesXmlParser parser, MNBArfolyamServiceSoapClient client)
        {
            this.parser = parser;
            this.client = client;
        }

        public string Source => "https://www.mnb.hu/arfolyamok.asmx";

        public async Task<DailyExchangeRateCollection> GetCurrentExchangeRatesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();
                var response = await client.GetCurrentExchangeRatesAsync(new GetCurrentExchangeRatesRequestBody());
                string result = response.GetCurrentExchangeRatesResponse1.GetCurrentExchangeRatesResult;
                return parser.Parse(result);
            }
            catch (Exception ex)
            {
                throw new InfrastructureException(ex);
            }
            finally
            {
                await client.CloseAsync();
            }
        }
    }
}