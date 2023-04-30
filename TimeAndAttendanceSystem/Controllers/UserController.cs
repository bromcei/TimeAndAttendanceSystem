using Microsoft.AspNetCore.Mvc;
using TimeAndAttendanceSystem.Repositories.Models.Entities;
using TimeAndAttendanceSystem.Services.Interfaces;

namespace TimeAndAttendanceSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthenticationService _authenticationService;

        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, IAuthenticationService authenticationService, ILogger<UserController> logger)
        {
            _userService = userService;
            _authenticationService = authenticationService;
            _logger = logger;
        }

        [HttpPost("registerUser")]
        public async Task<ActionResult<User>> RegisterUser(string username, string password)
        {
            var user = await _authenticationService.CreateUser(username, password);

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<bool>> login(string username, string password)
        {
            var loginResult = await _authenticationService.Login(username, password);

            return Ok(loginResult);
        }

        [HttpGet("getUser")]
        public async Task<ActionResult<User>> GetUserById(Guid userId)
        {
            var user = await _userService.GetUserByID(userId);
            if (user == null)
            {
                return NotFound("No data received");
            }
            return Ok(user);
        }
        [HttpGet("allUsers")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userService.GetAllUsers();
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }
    }
}