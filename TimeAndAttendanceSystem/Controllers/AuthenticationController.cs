using Microsoft.AspNetCore.Mvc;
using TimeAndAttendanceSystem.Repositories.Models.Entities;
using TimeAndAttendanceSystem.Services.Interfaces;

namespace JWT_API.Controllers;

public class AuthenticationController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IAuthenticationService _authenticationService;
    private readonly IUserService _userService; 
    private readonly IJwtService _jwtService;


    public AuthenticationController(
        IConfiguration configuration,
        IAuthenticationService authenticationService,
        IUserService userService,
        IJwtService jwtService
        )
    {
        _configuration = configuration;
        _authenticationService = authenticationService;
        _userService = userService;
        _jwtService = jwtService;
        
    }

    [HttpPost("registerUser")]
    public async Task<ActionResult<User>> RegisterUser(string username, string password)
    {
        var user = await _authenticationService.CreateUser(username, password);

        return Ok(user);
    }

    [HttpPost("login")]
    public async Task<ActionResult<string>> Login(string username, string password)
    {
        if(await _authenticationService.Login(username, password))
        {
            User user = await _userService.GetUserByUserName(username);
            var token = await _jwtService.GetJwtToken(username, user.UserRole);
            return token;
        }

        return null;
    }
   
}