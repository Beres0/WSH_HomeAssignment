using WSH_HomeAssignment.Domain.Entities;

namespace WSH_HomeAssignment.Domain.Repositories
{
    public interface IRepository<TEntity,TKey>
        where TEntity:class,IEntity<TKey>
    {
        Task<TEntity> GetAsync(TKey id,CancellationToken cancellationToken);
        Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken);
        Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken);
        Task<IPagedResult<TEntity>> GetListAsync(IPaginationArgs args, CancellationToken cancellationToken);
        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);
    }
    public interface IRepository<TEntity>
        where TEntity:class,IEntity
    {

    }

}