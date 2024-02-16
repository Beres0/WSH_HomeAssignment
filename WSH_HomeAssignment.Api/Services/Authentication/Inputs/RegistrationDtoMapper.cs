using WSH_HomeAssignment.Domain.Authentication;

namespace WSH_HomeAssignment.Api.Services.Authentication.Inputs
{
    public static class RegistrationDtoMapper
    {
        public static Registration ToDomainModel(this RegistrationDto dto)
        {
            return new Registration(dto.UserName, dto.Email, dto.Password);
        }
    }
}
