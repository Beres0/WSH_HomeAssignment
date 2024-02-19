namespace WSH_HomeAssignment.Domain.ExchangeRatesServices
{
    public interface IExternalExchangeRatesService : IExchangeRatesService
    {
        string Source { get; }
    }
}