using WSH_HomeAssignment.Domain.Entities;

namespace WSH_HomeAssignment.Domain.Repositories
{
    public interface IPagedResult<TEntity>
        where TEntity:class,IEntity
    {
        int TotalCount { get; }
        IPaginationArgs Args { get; }
        IList<TEntity> Result { get; }
    }
    public class PagedResult<TEntity> : IPagedResult<TEntity>
        where TEntity:class,IEntity
    {
        public PagedResult(int totalCount, IPaginationArgs args, IList<TEntity> result)
        {
            TotalCount = totalCount;
            Args = args;
            Result = result;
        }

        public int TotalCount { get; }
        public IPaginationArgs Args { get; }
        public IList<TEntity> Result { get;}
    }

}