using System.ComponentModel.DataAnnotations;

namespace Minimal.WebApi.Features.User.DTO;

public class AuthenticateUserDto
{
    /// <summary>Username for authentication.</summary>
    /// <example>tony_lore</example>
    [Required]
    public string Username { get; set; } = string.Empty;

    /// <summary>Password for authentication.</summary>
    /// <example>password123</example>
    [Required]
    public string Password { get; set; } = string.Empty;
}
