using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WSH_HomeAssignment.Domain.Authentication;
using WSH_HomeAssignment.Domain.Entities;

namespace WSH_HomeAssignment.Infrastructure.Authentication
{
    public class JwtTokenService : ITokenService
    {
        private readonly IConfiguration configuration;

        public JwtTokenService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Token CreateToken(User user)
        {
            var claim = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.NameId, user.Id!),
                    new Claim(JwtRegisteredClaimNames.Aud, configuration["JWT:ValidAudience"]!),
                    new Claim(JwtRegisteredClaimNames.Iss, configuration["JWT:ValidIssuer"]!)
                };
            var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]!));

            var creds = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claim),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new Token(user.Id, user.UserName, token.ValidTo, new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}