namespace WSH_HomeAssignment.Domain.Repository
{
    public interface IPaginationArgs
    {
       int Skip { get; }
       int Take { get; }
    }
}