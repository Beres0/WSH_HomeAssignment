using WSH_HomeAssignment.Api.Services.Authentication.Inputs;
using WSH_HomeAssignment.Api.Services.Authentication.Outputs;
using WSH_HomeAssignment.Domain.Authentication;

namespace WSH_HomeAssignment.Api.Services.Authentication
{
    public class AuthenticationAppService : IAuthenticationAppService
    {
        private IAuthenticationService service;

        public AuthenticationAppService(IAuthenticationService service)
        {
            this.service = service;
        }

        public async Task<TokenDto> RegisterAsync(RegistrationDto input)
        {
            var token = await service.RegisterAsync(input.ToDomainModel());
            return token.ToDto();
        }
        public async Task<TokenDto> LoginAsync(LoginDto input)
        {
            var token = await service.LoginAsync(input.ToDomainModel());
            return token.ToDto();
        }
    }
}
