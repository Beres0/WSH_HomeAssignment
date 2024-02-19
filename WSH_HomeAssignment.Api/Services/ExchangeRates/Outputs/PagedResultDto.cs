using WSH_HomeAssignment.Domain.Repositories;

namespace WSH_HomeAssignment.Api.Services.ExchangeRates.Outputs
{
    public class PagedResultDto<T> : IPagedResult<T>
    {
        public int TotalCount { get; set; }
        public PaginationArgsDto? Args { get; set; } = new PaginationArgsDto();
        public List<T> Result { get; set; } = new List<T>();
        public int ResultCount { get; set; }
        IPaginationArgs? IPagedResult<T>.Args => Args;

        IList<T> IPagedResult<T>.Result => Result;
    }
}