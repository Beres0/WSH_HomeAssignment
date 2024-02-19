namespace WSH_HomeAssignment.Domain.ExchangeRatesServices
{
    public interface ICachedExchangeRatesService : IExchangeRatesService
    {
        Task RefreshAsync(CancellationToken cancellationToken = default);
    }
}