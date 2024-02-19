using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Data;
using System.Security.Claims;
using WSH_HomeAssignment.Domain.Authentication;
using WSH_HomeAssignment.Domain.Entities;

namespace WSH_HomeAssignment.Infrastructure.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ITokenService tokenService;
        private readonly IPasswordHasher<IdentityUser> passwordHasher;
        private readonly IHttpContextAccessor accessor;
        private readonly UserManager<IdentityUser> userManager;

        public AuthenticationService(ITokenService tokenService,
                                     IPasswordHasher<IdentityUser> passwordHasher,
                                     IHttpContextAccessor accessor,
                                     UserManager<IdentityUser> userManager)
        {
            this.tokenService = tokenService;
            this.passwordHasher = passwordHasher;
            this.accessor = accessor;
            this.userManager = userManager;
        }

        public async Task<User?> FindUserAsync(string? id)
        {
            if (id is null) return null;
            var result = await userManager.FindByIdAsync(id);
            if (result is null) return null;
            return result.ToDomainModel();
        }

        public async Task<User> GetCurrentUserAsync()
        {
            return (await FindUserAsync(GetCurrentUserId()))!;
        }

        public string GetCurrentUserId()
        {
            var user = accessor.HttpContext?.User;
            var nameIdClaim = user?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (nameIdClaim is not null)
            {
                return nameIdClaim.Value;
            }
            else
            {
                throw AuthenticationException.LoginRequired;
            }
        }

        public async Task<Token> LoginAsync(Login login)
        {
            var user = await userManager.FindByNameAsync(login.UserName);
            if (user is null)
            {
                throw AuthenticationException.PasswordOrUserNameIsIncorrect;
            }
            var result = passwordHasher.VerifyHashedPassword(user!, user!.PasswordHash!, login.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                throw AuthenticationException.PasswordOrUserNameIsIncorrect;
            }
            return tokenService.CreateToken(user.ToDomainModel());
        }

        public async Task<Token> RefreshTokenAsync()
        {
            var user = await FindUserAsync(GetCurrentUserId());
            if (user is null)
            {
                throw AuthenticationException.LoginRequired;
            }
            return tokenService.CreateToken(user);
        }

        public async Task<Token> RegisterAsync(Registration registration)
        {
            var newUser = registration.ToIdentity();
            newUser.PasswordHash = passwordHasher.HashPassword(newUser, registration.Password);

            var result = await userManager.CreateAsync(newUser);
            if (!result.Succeeded)
            {
                throw new AuthenticationException(result.Errors.Select(e => e.Description));
            }
            return tokenService.CreateToken(newUser.ToDomainModel());
        }
    }
}