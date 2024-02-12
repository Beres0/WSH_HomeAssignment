namespace WSH_HomeAssignment.Domain.Repository
{
    public interface IEntity<TKey>
    {
        TKey Id { get; }
    }
}