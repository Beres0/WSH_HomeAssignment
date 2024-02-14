namespace WSH_HomeAssignment.Domain.Entities
{
    public interface IEntity<TKey>:IEntity
    {
        TKey Id { get; }
    }
    public interface IEntity 
    {
        public object[] GetKey();
    }
}