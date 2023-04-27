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

        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
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