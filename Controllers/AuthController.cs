using Microsoft.AspNetCore.Mvc;
using ApiWithTokenJWT.Dtos;
using ApiWithTokenJWT.Services.AuthRegister;

namespace ApiWithTokenJWT.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserRegister _userRegister;
    private readonly ILogin _login;

    public AuthController(IUserRegister userRegister, ILogin login)
    {
        _userRegister = userRegister;
        _login = login;
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        var responseLogin = await _login.Login(loginDto);
        
        return Ok(responseLogin);
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> RegisterUsers([FromBody] UsersDto userRegister)
    {
     var registerResponse = await  _userRegister.Registrar(userRegister);
        
        
        return Ok(registerResponse);
    }
}