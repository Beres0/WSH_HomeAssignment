namespace WSH_HomeAssignment.Domain.Repositories
{
    public interface IPaginationArgs
    {
        int Skip { get; }
        int Take { get; }
    }
}