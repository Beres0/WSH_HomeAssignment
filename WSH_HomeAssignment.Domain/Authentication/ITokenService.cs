using WSH_HomeAssignment.Domain.Authentication;
using WSH_HomeAssignment.Domain.Entities;

namespace WSH_HomeAssignment.Infrastructure.Authentication
{
    public interface ITokenService
    {
        Token CreateToken(User user);
    }
}