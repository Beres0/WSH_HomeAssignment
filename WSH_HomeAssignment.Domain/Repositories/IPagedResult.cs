namespace WSH_HomeAssignment.Domain.Repositories
{
    public interface IPagedResult<T>
    {
        int TotalCount { get; }
        IPaginationArgs? Args { get; }
        IList<T> Result { get; }
    }

    public class PagedResult<T> : IPagedResult<T>
    {
        public PagedResult(int totalCount, IPaginationArgs? args, IList<T> result)
        {
            TotalCount = totalCount;
            Args = args;
            Result = result;
        }

        public int TotalCount { get; }
        public IPaginationArgs? Args { get; }
        public IList<T> Result { get; }
    }
}