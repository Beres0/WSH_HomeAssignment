using WSH_HomeAssignment.Domain.Entities;

namespace WSH_HomeAssignment.Api.Services.ExchangeRates.Outputs
{
    public class SavedDailyExchangeRatesDto
    {
        public DateDto Date { get; set; } = null!;
        public Dictionary<string, ExchangeRateDto> ExchangeRates { get; set; } = new();
        public Dictionary<string, string?> Notes { get; set; } = new();
    }

    public static class SavedDailyExchangeRatesDtoMapper
    {
        public static SavedDailyExchangeRatesDto ToDto(this SavedDailyExchangeRateCollection exchangeRates)
        {
            return new SavedDailyExchangeRatesDto()
            {
                Date = exchangeRates.Date.ToDto(),
                ExchangeRates = exchangeRates.ToDictionary(r => r.Key, r => r.Value.ToDto()),
                Notes = new Dictionary<string, string?>(exchangeRates.GetNotes())
            };
        }
    }
}