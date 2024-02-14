namespace WSH_HomeAssignment.Domain.Exceptions
{
    public class InfrastructureException:Exception
    {
        public InfrastructureException(Exception? innerException,string? message=null):base(message,innerException)
        {
        }
    }
}
