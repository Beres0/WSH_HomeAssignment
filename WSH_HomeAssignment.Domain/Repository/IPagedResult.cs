namespace WSH_HomeAssignment.Domain.Repository
{
    public interface IPagedResult<TEntity,TKey>
        where TEntity:class,IEntity<TKey>
    {
        int TotalCount { get; }
        IPaginationArgs Args { get; }
        IList<TEntity> Result { get; }
    }
}