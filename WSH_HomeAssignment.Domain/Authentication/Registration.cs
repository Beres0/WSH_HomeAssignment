using WSH_HomeAssignment.Domain.Entities;

namespace WSH_HomeAssignment.Domain.Authentication
{
    public class Registration
    {
        public Registration(string userName, string email, string password)
        {
            InvalidArgumentException.CheckNullOrWhiteSpace(email);
            InvalidArgumentException.CheckNullOrWhiteSpace(userName);
            InvalidArgumentException.CheckNullOrWhiteSpace(password);
            InvalidArgumentException.CheckMinLength(password, DomainConstants.PasswordRequiredLength);
            UserName = userName;
            Email = email;
            Password = password;
        }

        public string UserName { get; }
        public string Email { get; }
        public string Password { get; }
    }
}