namespace WSH_HomeAssignment.Domain.Authentication
{
    public class Token
    {
        public Token(string userId, string userName, DateTime expiration, string value)
        {
            InvalidArgumentException.CheckNullOrWhiteSpace(userName);
            InvalidArgumentException.CheckNullOrWhiteSpace(userId);
            InvalidArgumentException.CheckNullOrWhiteSpace(value);
            UserId = userId;
            UserName = userName;
            Expiration = expiration;
            Value = value;
        }

        public string UserId { get; }
        public string UserName { get; }
        public DateTime Expiration { get; }
        public string Value { get; }
    }
}