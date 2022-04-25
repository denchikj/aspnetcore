using System.ComponentModel.DataAnnotations;

namespace Minimal.WebApi.Features.User.DTO;

public class ReadUserDto
{
    /// <summary>User identifier.</summary>
    /// <example>xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx</example>
    public Guid Id { get; set; }

    /// <summary>User display name.</summary>
    /// <example>Tony Lore</example>
    public string DisplayName { get; set; } = string.Empty;

    /// <summary>Username for authorization.</summary>
    /// <example>tony_lore</example>
    public string Username { get; set; } = string.Empty;
}
