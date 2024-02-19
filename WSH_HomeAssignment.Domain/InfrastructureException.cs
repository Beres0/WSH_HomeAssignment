namespace WSH_HomeAssignment.Domain
{
    public class InfrastructureException : DomainException
    {
        public InfrastructureException(Exception? innerException, string? message = null) : base(message, innerException)
        {
            ErrorCode = 4000;
        }
    }
}