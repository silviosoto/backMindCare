using API.Models;
using Azure;
using Data.Contracts;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;
using System.Security.Claims;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IJwtAuthManager _jwtAuthManager;
    private readonly IRepository<User> _repository;
    private readonly IRepository<Perfil> _repositoryPerfil;
    public AuthController(IJwtAuthManager jwtAuthManager,
          IRepository<User> repository,
          IRepository<Perfil> repositoryPerfil
        )
    {
        _jwtAuthManager = jwtAuthManager;
        _repository = repository;
        _repositoryPerfil = repositoryPerfil;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        // Aquí verificarías el usuario y contraseña contra una base de datos
        bool exists = await _repository.ExistsAsync(c => 
            c.Username == request.Username && c.Password == request.Password);

        if (exists==false)
        {
            return Unauthorized();
        }
 
        User user = await _repository.GetSingleOrDefaultAsync(c => c.Username == request.Username);
        if (user == null)
        {
            return NotFound();
        }
        Perfil perfil = await _repositoryPerfil.GetByIdAsync(user.idPerfil);
        if (perfil == null)
        {
            return NotFound();
        }
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, request.Username),
            new Claim(ClaimTypes.Role, "admin")
        };

        var jwtResult = _jwtAuthManager.GenerateTokens(request.Username, claims, DateTime.Now);
        //SetRefreshTokenInCookie(jwtResult.RefreshToken.TokenString);

        return Ok(new LoginResult
        {
            UserId = user.Id,
            UserName = user.Username,
            Profile = perfil.nombre,
            AccessToken = jwtResult.AccessToken,
            RefreshToken = jwtResult.RefreshToken.TokenString
        });
    }

    [HttpPost("refresh-token")]
    public IActionResult RefreshToken([FromBody] RefreshTokenRequest request)
    {
        try
        {
            var jwtResult = _jwtAuthManager.Refresh(request.RefreshToken, request.AccessToken, DateTime.Now);
            //SetRefreshTokenInCookie(jwtResult.RefreshToken.TokenString);
            return Ok(new LoginResult
            {
                AccessToken = jwtResult.AccessToken,
                RefreshToken = jwtResult.RefreshToken.TokenString
            });
        }
        catch (SecurityTokenException e)
        {
            return Unauthorized(e.Message); // return 401 so that the client side can redirect the user to login page
        }
    }

    private void SetRefreshTokenInCookie(string refreshToken)
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = DateTime.UtcNow.AddDays(7)
        };
        Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
    }
}
