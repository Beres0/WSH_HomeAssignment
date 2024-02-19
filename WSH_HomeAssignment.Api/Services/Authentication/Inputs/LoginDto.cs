using System.ComponentModel.DataAnnotations;
using WSH_HomeAssignment.Domain.Entities;

namespace WSH_HomeAssignment.Api.Services.Authentication.Inputs
{
    public class LoginDto
    {
        [Required]
        public string UserName { get; set; } = null!;

        [Required]
        [MinLength(DomainConstants.PasswordRequiredLength)]
        public string Password { get; set; } = null!;
    }
}