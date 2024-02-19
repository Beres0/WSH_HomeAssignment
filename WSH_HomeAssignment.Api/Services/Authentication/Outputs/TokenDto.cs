using WSH_HomeAssignment.Domain.Authentication;

namespace WSH_HomeAssignment.Api.Services.Authentication.Outputs
{
    public class TokenDto
    {
        public string UserId { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public DateTime Expiration { get; set; }
        public string Value { get; set; } = null!;
    }

    public static class TokenDtoMapper
    {
        public static TokenDto ToDto(this Token token)
        {
            return new TokenDto()
            {
                UserId = token.UserId,
                UserName = token.UserName,
                Expiration = token.Expiration,
                Value = token.Value,
            };
        }
    }
}