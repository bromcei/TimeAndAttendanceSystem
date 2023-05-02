using Microsoft.AspNetCore.Mvc;
using TimeAndAttendanceSystem.Repositories.Models.DTOs;
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
    public async Task<ActionResult<UserDTO>> RegisterUser(string username, string password)
    {
        var user = await _authenticationService.CreateUser(username, password);

        return Ok(user);
    }

    [HttpPost("login")]
    public async Task<ActionResult<string>?> Login(string username, string password)
    {
        if(await _authenticationService.Login(username, password))
        {
            UserDTO? user = await _userService.GetUserByUserName(username);
            if(user != null)
            {
                var token = await _jwtService.GetJwtToken(username, user.Id, user.UserRole);
                return token;
            }
            return null;
        }
        return null;
    }
   
}