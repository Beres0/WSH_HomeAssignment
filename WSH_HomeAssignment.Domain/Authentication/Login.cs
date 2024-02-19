using WSH_HomeAssignment.Domain.Entities;

namespace WSH_HomeAssignment.Domain.Authentication
{
    public class Login
    {
        public string UserName { get; }
        public string Password { get; }

        public Login(string userName, string password)
        {
            InvalidArgumentException.CheckNullOrWhiteSpace(userName);
            InvalidArgumentException.CheckNullOrWhiteSpace(password);
            InvalidArgumentException.CheckMinLength(password, DomainConstants.PasswordRequiredLength);
            UserName = userName;
            Password = password;
        }
    }
}