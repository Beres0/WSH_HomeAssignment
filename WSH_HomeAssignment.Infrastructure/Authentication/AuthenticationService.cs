using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Data;
using WSH_HomeAssignment.Domain.Authentication;
using WSH_HomeAssignment.Domain.Entities;
using WSH_HomeAssignment.Domain.Repositories;
using WSH_HomeAssignment.Infrastructure.Data.Models;

namespace WSH_HomeAssignment.Infrastructure.Authentication
{
    public class AuthenticationService:IAuthenticationService
    {
        private readonly ITokenService tokenService;
        private readonly IPasswordHasher<IdentityUser> passwordHasher;
        private readonly UserManager<IdentityUser> userManager;

        public AuthenticationService(ITokenService tokenService,IPasswordHasher<IdentityUser> passwordHasher, UserManager<IdentityUser> userManager)
        {
            this.tokenService = tokenService;
            this.passwordHasher = passwordHasher;
            this.userManager = userManager;
        }

        public async Task<User?> FindUserAsync(string? id)
        {
            if (id is null) return null;
            var result=await userManager.FindByIdAsync(id);
            if (result is null) return null;
            return result.ToDomainModel();
        }
        public async Task<Token> LoginAsync(Login login)
        {
            var user = await userManager.FindByNameAsync(login.UserName);
            if(user is null)
            {
                AuthenticationException.ThrowPasswordOrUserNameIsIncorrect();
            }
            var result=passwordHasher.VerifyHashedPassword(user!, user!.PasswordHash!, login.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                AuthenticationException.ThrowPasswordOrUserNameIsIncorrect();
            }
            return tokenService.CreateToken(user);
        }

        public async Task<Token> RegisterAsync(Registration registration)
        {
            var newUser = registration.ToIdentity();
            newUser.PasswordHash = passwordHasher.HashPassword(newUser, registration.Password);

            var result=await userManager.CreateAsync(newUser);
            if (!result.Succeeded)
            {
                throw new AuthenticationException(result.Errors.Select(e => e.Description));
            }
            return tokenService.CreateToken(newUser);
        }

       
    }
}
