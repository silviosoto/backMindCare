using System.Security.Claims;

public interface IJwtAuthManager
{
    JwtAuthResult GenerateTokens(string username, Claim[] claims, DateTime now);
    JwtAuthResult Refresh(string refreshToken, string accessToken, DateTime now);
}
