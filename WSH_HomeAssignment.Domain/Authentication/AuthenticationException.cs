namespace WSH_HomeAssignment.Domain.Authentication
{
    public class AuthenticationException : Exception
    {
        public static AuthenticationException ThrowPasswordOrUserNameIsIncorrect()
        {
            throw new AuthenticationException("password or username is incorrect");
        }
        public IEnumerable<string> Details { get; }
        public AuthenticationException(string message) : base(message)
        {
            Details = new string[] { message };
        }
        public AuthenticationException(IEnumerable<string> errors) : base(string.Join("\n", errors.ToString()))
        {
            Details = errors;
        }
    }
}
