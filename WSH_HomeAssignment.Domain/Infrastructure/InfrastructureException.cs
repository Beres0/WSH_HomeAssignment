namespace WSH_HomeAssignment.Domain.Infrastructure
{
    public class InfrastructureException:Exception
    {
        public InfrastructureException(Exception? innerException,string? message=null):base(message,innerException)
        {
        }
    }
}
