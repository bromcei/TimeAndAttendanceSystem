using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TimeAndAttendanceSystem.Repositories.Models.DTOs;
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


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user, admin")]
        [HttpGet("getUser")]
        public async Task<ActionResult<User>> GetUser()
        {
            var userName = User.Identity.Name;
            var user = await _userService.GetUserByUserName(userName);
            if (user == null)
            {
                return NotFound("No data received");
            }
            return Ok(user);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user, admin")]
        [HttpGet("getUserDetails")]
        public async Task<ActionResult<UserDetailsDTO>> GetUserDetails()
        {
            var userName = User.Identity.Name;
            var user = await _userService.GetUserByUserName(userName);
            
            if (user != null)
            {
                UserDetailsDTO userDetails = await _userService.GetUserDetails(userName);
                if(userDetails != null)
                    return Ok(userDetails);
                return NotFound($"User {user.Id} does not have any details");
            }

            return NotFound("Such user doewsnt exists");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user, admin")]
        [HttpPost("postUserDetails")]
        public async Task<ActionResult<String>> PostUserDetails(
            [Required][StringLength(50, MinimumLength = 2)] string firstName,
            [Required][StringLength(50, MinimumLength = 2)] string lastName,
            [Required] long personCode,
            [Required][StringLength(12, MinimumLength = 2)] string phoneNumber,
            [Required][StringLength(50, MinimumLength = 2)] string email)
        {
            var userName = User.Identity.Name;
            var user = await _userService.GetUserByUserName(userName);
            if (user != null)
            {
                Guid userId = user.Id;
                UserDetailsDTO userDetails = await _userService.CreateUserDetails(userId, firstName, lastName, personCode, phoneNumber, email);
                return Ok($"User {userName} details was added");
            }

            return NotFound("Such user does not exists");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user, admin")]
        [HttpPut("updateUserFirstName")]
        public async Task<ActionResult<String>> UpdateUserFirstName([Required][StringLength(50, MinimumLength = 2)] string newFirstName)
        {
            var userName = User.Identity.Name;
            var user = await _userService.GetUserByUserName(userName);
            if (user != null)
            {
                Guid userId = user.Id;
                await _userService.UpdateUserFirstName(userId, newFirstName);
                return Ok($"User {userName} first name was changed to '{newFirstName}'");
            }

            return NotFound("Such user does not exists");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user, admin")]
        [HttpPut("updateUserLastName")]
        public async Task<ActionResult<String>> UpdateUserLastName([Required][StringLength(50, MinimumLength = 2)] string newLastName)
        {
            var userName = User.Identity.Name;
            var user = await _userService.GetUserByUserName(userName);
            if (user != null)
            {
                Guid userId = user.Id;
                await _userService.UpdateUserLastName(userId, newLastName);
                return Ok($"User {userName} last name was changed to '{newLastName}'");
            }

            return NotFound("Such user does not exists");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user, admin")]
        [HttpPut("updateUserPersonCode")]
        public async Task<ActionResult<String>> UpdateUserLastName([Required] long newPersonCode)
        {
            var userName = User.Identity.Name;
            var user = await _userService.GetUserByUserName(userName);
            if (user != null)
            {
                Guid userId = user.Id;
                await _userService.UpdateUserPersonCode(userId, newPersonCode);
                return Ok($"User {userName} person code was changed");
            }

            return NotFound("Such user does not exists");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user, admin")]
        [HttpPut("updateUserPhoneNumber")]
        public async Task<ActionResult<String>> UpdateUserPhoneNumber([Required] string newPhoneNumber)
        {
            var userName = User.Identity.Name;
            var user = await _userService.GetUserByUserName(userName);
            if (user != null)
            {
                Guid userId = user.Id;
                await _userService.UpdateUserTelephone(userId, newPhoneNumber);
                return Ok($"User {userName} telephone number was changed");
            }

            return NotFound("Such user does not exists");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user, admin")]
        [HttpPut("updateUserEmail")]
        public async Task<ActionResult<String>> UpdateUserEmail([Required] string newEmail)
        {
            var userName = User.Identity.Name;
            var user = await _userService.GetUserByUserName(userName);
            if (user != null)
            {
                Guid userId = user.Id;
                await _userService.UpdateUserEmail(userId, newEmail);
                return Ok($"User {userName} telephone number was changed");
            }

            return NotFound("Such user does not exists");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user, admin")]
        [HttpGet("getUserById")]
        public async Task<ActionResult<User>> GetUserById(Guid userId)
        {
            var userName = User.Identity.Name;
            var user = await _userService.GetUserByID(userId);
            if (user == null)
            {
                return NotFound("No data received");
            }
            return Ok(user);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user")]
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