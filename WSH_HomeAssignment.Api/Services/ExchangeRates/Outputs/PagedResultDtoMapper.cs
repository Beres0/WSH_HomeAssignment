using WSH_HomeAssignment.Domain.Repositories;

namespace WSH_HomeAssignment.Api.Services.ExchangeRates.Outputs
{
    public static class PagedResultDtoMapper
    {
        public static PagedResultDto<TResult> ToDto<T, TResult>(this IPagedResult<T> pagedResult, Func<T, TResult> transform)
        {
            return new PagedResultDto<TResult>()
            {
                Args = pagedResult.Args?.ToDto(),
                Result = pagedResult.Result.Select(transform).ToList(),
                TotalCount = pagedResult.TotalCount,
                ResultCount = pagedResult.Result.Count
            };
        }
    }
}