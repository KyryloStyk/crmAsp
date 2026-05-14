using Microsoft.AspNetCore.Mvc;
using api.DTOs.Auth;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<AuthResponseDto>> Register(RegisterDto dto)
    {
        var token = await _authService.RegisterAsync(dto);

        return Ok(new AuthResponseDto
        {
            Token = token
        });
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthResponseDto>> Login(LoginDto dto)
    {
        var token = await _authService.LoginAsync(dto);

        return Ok(new AuthResponseDto
        {
            Token = token
        });
    }
}