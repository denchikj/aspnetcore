namespace Minimal.WebApi.Features.User.Helpers;

public class TokenPair
{
    public TokenPair(string accessToken, string refreshToken)
    {
        AccessToken = accessToken;
        RefreshToken = refreshToken;
    }

    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}