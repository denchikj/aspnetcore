using System.ComponentModel.DataAnnotations;

namespace Minimal.WebApi.Features.User.DTO;

public class RegisterUserDto
{
    /// <summary>User display name.</summary>
    /// <example>Tony Lore</example>
    [Required]
    [MaxLength(50)]
    [RegularExpression(@"^[\w\s]*$")]
    public string DisplayName { get; set; } = string.Empty;

    /// <summary>Username for authorization.</summary>
    /// <example>tony_lore</example>
    [Required]
    [MaxLength(30)]
    [RegularExpression(@"^[\w\s\d]*$")]
    public string Username { get; set; } = string.Empty;

    /// <summary>Password for authorization.</summary>
    /// <example>password123</example>
    [Required]
    [MinLength(6)]
    [MaxLength(20)]
    [RegularExpression(@"^[\w\s\d]*$")]
    public string Password { get; set; } = string.Empty;
}
