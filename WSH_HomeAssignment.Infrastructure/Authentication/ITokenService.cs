using Microsoft.AspNetCore.Identity;
using WSH_HomeAssignment.Domain.Authentication;

namespace WSH_HomeAssignment.Infrastructure.Authentication
{
    public interface ITokenService
    {
        Token CreateToken(IdentityUser user);
    }
}
