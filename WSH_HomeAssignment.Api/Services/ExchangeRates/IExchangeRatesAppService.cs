using WSH_HomeAssignment.Api.Services.ExchangeRates;
using WSH_HomeAssignment.Api.Services.ExchangeRates.Inputs;
using WSH_HomeAssignment.Api.Services.ExchangeRates.Outputs;

namespace WSH_HomeAssignment.Api.Services.ExchangeRates
{
    public interface IExchangeRatesAppService
    {
        Task<DailyExchangeRatesDto> GetCurrentAsync();
        Task<SavedDailyExchangeRatesDto> GetSavedCurrentAsync();
        Task<SavedExchangeRateDto> GetSavedAsync(DateDto date, string currency);
        Task<PagedResultDto<SavedExchangeRateDto>> GetSavedListAsync(PaginationArgsDto input);
        Task<SavedExchangeRateDto> CreateSavedAsync(DateDto date,string currency,CreateUpdateSavedExchangeRateDto input);
        Task<SavedExchangeRateDto> UpdateSavedAsync(DateDto date,string currency,CreateUpdateSavedExchangeRateDto input);
        Task DeleteSavedAsync(DateDto date, string currency);
    }
}