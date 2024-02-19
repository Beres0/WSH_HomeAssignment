using WSH_HomeAssignment.Domain.Entities;

namespace WSH_HomeAssignment.Domain.Authentication
{
    public interface IAuthenticationService
    {
        Task<User> GetCurrentUserAsync();

        string GetCurrentUserId();

        Task<Token> RegisterAsync(Registration registration);

        Task<Token> LoginAsync(Login login);

        Task<User?> FindUserAsync(string? userId);

        Task<Token> RefreshTokenAsync();
    }
}