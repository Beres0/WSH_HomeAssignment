using WSH_HomeAssignment.Domain.Authentication;

namespace WSH_HomeAssignment.Api.Services.Authentication.Inputs
{
    public static class LoginDtoMapper
    {
        public static Login ToDomainModel(this LoginDto dto)
        {
            return new Login(dto.UserName, dto.Password);
        }
    }
}
