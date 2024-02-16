namespace WSH_HomeAssignment.Api.Services.ExchangeRates.Outputs
{
    public class SavedExchangeRateDto
    {
        public DateOnly Date { get; set; }
        public string Currency { get; set; } = null!;
        public int Unit { get; set; }
        public double Value { get; set; }
        public string? Note { get; set; }
    }
}
