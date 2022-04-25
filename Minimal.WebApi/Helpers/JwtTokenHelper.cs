using Microsoft.IdentityModel.Tokens;
using Minimal.WebApi.Extensions;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Minimal.WebApi.Helpers;

public class JwtTokenHelper
{
    private readonly JwtSecurityTokenHandler _tokenHandler;
    private readonly IConfiguration _configuration;

    public JwtTokenHelper(IConfiguration configuration)
    {
        _tokenHandler = new JwtSecurityTokenHandler();
        _tokenHandler.InboundClaimTypeMap.Clear();
        _tokenHandler.OutboundClaimTypeMap.Clear();

        _configuration = configuration;
    }

    public IDictionary<string, string> ParseToken(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            RequireSignedTokens = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = _configuration.GetAuthSecret(),
            ValidateAudience = false,
            ValidateIssuer = false,
            RequireExpirationTime = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };

        try
        {
            var claimsPrincipal = _tokenHandler.ValidateToken(token, tokenValidationParameters, out _);
            return claimsPrincipal.Claims.ToDictionary(claim => claim.Type, claim => claim.Value);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public IDictionary<string, string> ParseToken(string token, byte[] jwtSecret)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        tokenHandler.InboundClaimTypeMap.Clear();
        tokenHandler.OutboundClaimTypeMap.Clear();

        var tokenValidationParameters = new TokenValidationParameters
        {
            RequireSignedTokens = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(jwtSecret),

            ValidateAudience = false,
            ValidateIssuer = false,

            RequireExpirationTime = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };

        try
        {
            var claimsPrincipal = tokenHandler.ValidateToken(token, tokenValidationParameters, out _);
            return claimsPrincipal.Claims.ToDictionary(claim => claim.Type, claim => claim.Value);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public string IssueToken(IDictionary<string, object> claims, TimeSpan lifetime)
    {
        var descriptor = new SecurityTokenDescriptor
        {
            Claims = claims,
            Expires = DateTime.UtcNow.Add(lifetime),
            SigningCredentials = new SigningCredentials(_configuration.GetAuthSecret(),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenObject = _tokenHandler.CreateToken(descriptor);
        var encodedToken = _tokenHandler.WriteToken(tokenObject);

        return encodedToken;
    }

    public TokenPair IssueTokenPair(Guid userId, Guid rtId)
    {
        var accessToken = IssueToken(
            new Dictionary<string, object>
            {
                {"sub", userId}
            },
            _configuration.GetAccessTokenLifetime());

        var refreshToken = IssueToken(
            new Dictionary<string, object>
            {
                {"sub", userId},
                {"jti", rtId}
            },
            _configuration.GetRefreshTokenLifetime());

        return new TokenPair(accessToken, refreshToken);
    }

    public record TokenPair(string AccessToken, string RefreshToken);
}
