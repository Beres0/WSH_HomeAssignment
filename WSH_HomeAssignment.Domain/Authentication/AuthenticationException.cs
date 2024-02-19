namespace WSH_HomeAssignment.Domain.Authentication
{
    public class AuthenticationException : DomainException
    {
        public static readonly AuthenticationException PasswordOrUserNameIsIncorrect = new AuthenticationException("password or username is incorrect")
        {
            ErrorCode = 3001
        };

        public static readonly AuthenticationException LoginRequired = new AuthenticationException("login required")
        {
            ErrorCode = 3002
        };

        public AuthenticationException(string message) : base(message)
        {
            ErrorCode = 3000;
        }

        public AuthenticationException(IEnumerable<string> errors) : this(string.Join("\n", errors))
        {
        }
    }
}