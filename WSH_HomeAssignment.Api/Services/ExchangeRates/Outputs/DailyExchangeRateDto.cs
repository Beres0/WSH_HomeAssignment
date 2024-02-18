
namespace WSH_HomeAssignment.Api.Services.ExchangeRates.Outputs
{
    public class DailyExchangeRateDto 
    { 
        public DateDto Date { get; set; } = null!;
        public string Currency { get; set; } = null!;
        public int Unit { get; set; }
        public double Value { get; set; }
    }
  
}
