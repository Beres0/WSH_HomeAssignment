using Microsoft.AspNetCore.Identity;
using WSH_HomeAssignment.Domain.Authentication;
using WSH_HomeAssignment.Domain.Entities;

namespace WSH_HomeAssignment.Infrastructure.Authentication
{
    internal static class IdentityUserMapper
    {
        public static User ToDomainModel(this IdentityUser user)
        {
            return new User(user.Id, user.UserName!, user.Email!);
        }

        public static IdentityUser ToIdentity(this Registration registration)
        {
            return new IdentityUser()
            {
                UserName = registration.UserName,
                NormalizedUserName = registration.UserName.ToUpper(),
                Email = registration.Email,
                NormalizedEmail = registration.Email.ToUpper(),
            };
        }
    }
}