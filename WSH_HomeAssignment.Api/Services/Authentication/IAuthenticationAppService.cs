using WSH_HomeAssignment.Api.Services.Authentication.Inputs;
using WSH_HomeAssignment.Api.Services.Authentication.Outputs;

namespace WSH_HomeAssignment.Api.Services.Authentication
{
    public interface IAuthenticationAppService
    {
        Task<TokenDto> LoginAsync(LoginDto input);

        Task<TokenDto> RegisterAsync(RegistrationDto input);

        Task<TokenDto> RefreshAsync();
    }
}