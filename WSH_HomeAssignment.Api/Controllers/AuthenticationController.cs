using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSH_HomeAssignment.Api.Services.Authentication;
using WSH_HomeAssignment.Api.Services.Authentication.Inputs;
using WSH_HomeAssignment.Api.Services.Authentication.Outputs;

namespace WSH_HomeAssignment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase,IAuthenticationAppService
    {
        private readonly IAuthenticationAppService service;

        public AuthenticationController(IAuthenticationAppService service)
        {
            this.service = service;
        }
        [HttpPost("login")]
        public Task<TokenDto> LoginAsync([FromBody]LoginDto input)
        {
            return service.LoginAsync(input);
        }

        [HttpPost("register")]
        public Task<TokenDto> RegisterAsync([FromBody]RegistrationDto input)
        {
            return service.RegisterAsync(input);
        }
    }
}
