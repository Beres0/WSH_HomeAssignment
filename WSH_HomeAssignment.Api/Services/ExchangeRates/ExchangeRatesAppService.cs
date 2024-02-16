using Microsoft.AspNetCore.Identity;
using WSH_HomeAssignment.Api.Services.ExchangeRates.Outputs;
using WSH_HomeAssignment.Domain.Infrastructure;
using WSH_HomeAssignment.Domain.Repositories;

namespace WSH_HomeAssignment.Api.Services.Application
{
    public class ExchangeRatesAppService : IExchangeRatesAppService
    {
        private readonly IExchangeRatesService exchangeRatesService;
        private readonly ISavedExchangeRateRepository savedExchangeRateRepository;

        public ExchangeRatesAppService(IExchangeRatesService exchangeRatesService, ISavedExchangeRateRepository savedExchangeRateRepository)
        {
            this.exchangeRatesService = exchangeRatesService;
            this.savedExchangeRateRepository = savedExchangeRateRepository;
        }
        public async Task<DailyExchangeRatesDto> GetCurrentExchangeRatesAsync()
        {
            var current = await exchangeRatesService.GetCurrentExchangeRatesAsync();
            return current.ToDto();
        }
    }
}
