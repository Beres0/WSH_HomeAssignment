using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WSH_HomeAssignment.Api.Services.ExchangeRates;
using WSH_HomeAssignment.Api.Services.ExchangeRates.Inputs;
using WSH_HomeAssignment.Api.Services.ExchangeRates.Outputs;
using WSH_HomeAssignment.Domain.Authentication;
using WSH_HomeAssignment.Domain.ExchangeRatesServices;
using WSH_HomeAssignment.Domain.Repositories;

namespace WSH_HomeAssignment.Api.Services.ExchangeRates
{
    public class ExchangeRatesAppService : IExchangeRatesAppService
    {
        private readonly IExchangeRatesService exchangeRatesService;
        private readonly ISavedExchangeRateRepository savedExchangeRateRepository;
        private readonly IDailyExchangeRateRepository dailyExchangeRateRepository;
        private readonly IAuthenticationService authService;

        public ExchangeRatesAppService(IExchangeRatesService exchangeRatesService,
                                       ISavedExchangeRateRepository savedExchangeRateRepository,
                                       IDailyExchangeRateRepository dailyExchangeRateRepository,
                                       IAuthenticationService authService)
        {
            this.exchangeRatesService = exchangeRatesService;
            this.savedExchangeRateRepository = savedExchangeRateRepository;
            this.dailyExchangeRateRepository = dailyExchangeRateRepository;
            this.authService = authService;
        }

        public async Task<SavedExchangeRateDto> CreateSavedAsync(DateDto date, string currency, CreateUpdateSavedExchangeRateDto input)
        {
            var userId = authService.GetCurrentUserId();
            var daily=await dailyExchangeRateRepository.GetAsync(date.ToDateOnly(), currency);
            var saved = await savedExchangeRateRepository.CreateAsync(input.ToDomainModel(daily, userId));
            await savedExchangeRateRepository.SaveChangesAsync();
            return saved.ToDto();
        }


        public async Task DeleteSavedAsync(DateDto date, string currency)
        {
            var userId = authService.GetCurrentUserId();
            await savedExchangeRateRepository.DeleteAsync(date.ToDateOnly(), currency, userId);
            await savedExchangeRateRepository.SaveChangesAsync();
        }

        public async Task<SavedDailyExchangeRatesDto> GetSavedCurrentAsync()
        {
            var current = await exchangeRatesService.GetCurrentExchangeRatesAsync();
            var userId = authService.GetCurrentUserId();
            return (await savedExchangeRateRepository.GetAsync(current.Date, userId)).ToDto();
        }
        public async Task<DailyExchangeRatesDto> GetCurrentAsync()
        {
            return (await exchangeRatesService.GetCurrentExchangeRatesAsync()).ToDto();
        }

        public async Task<SavedExchangeRateDto> GetSavedAsync(DateDto date, string currency)
        {
            var userId = authService.GetCurrentUserId();
            var saved = await savedExchangeRateRepository.GetAsync(date.ToDateOnly(), currency,userId);
            return saved.ToDto();
        }

   
        public async Task<PagedResultDto<SavedExchangeRateDto>> GetSavedListAsync(PaginationArgsDto input)
        {
            var userId = authService.GetCurrentUserId();
            var result = await savedExchangeRateRepository.GetListAsync(userId, input);
            return result.ToDto(r => r.ToDto());
        }

        public async Task<SavedExchangeRateDto> UpdateSavedAsync(DateDto date, string currency, CreateUpdateSavedExchangeRateDto input)
        {
            var userId = authService.GetCurrentUserId();
            var daily = await dailyExchangeRateRepository.GetAsync(date.ToDateOnly(), currency);
            var saved = await savedExchangeRateRepository.UpdateAsync(input.ToDomainModel(daily, userId));
            await savedExchangeRateRepository.SaveChangesAsync();
            return saved.ToDto();
        }
    }
}
