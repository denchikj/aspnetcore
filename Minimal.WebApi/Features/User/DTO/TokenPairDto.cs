﻿namespace Minimal.WebApi.Features.User.DTO;

public class TokenPairDto
{
    /// <summary>JWT Access Token.</summary>
    /// <example>header.payload.signature</example>
    public string AccessToken { get; set; } = string.Empty;

    /// <summary>JWT Refresh Token.</summary>
    /// <example>header.payload.signature</example>
    public string RefreshToken { get; set; } = string.Empty;
}
