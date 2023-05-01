using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using TimeAndAttendanceSystem.Repositories.Models.DTOs;
using TimeAndAttendanceSystem.Repositories.Models.Entities;
using TimeAndAttendanceSystem.Services.Interfaces;
using TimeAndAttendanceSystem.Services.Requests;
using TimeAndAttendanceSystem.Services.Services;


namespace TimeAndAttendanceSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;
        private readonly IImageReshapeService _imageReshapeService;

        public UserController(IUserService userService, IImageReshapeService imageReshapeService, ILogger<UserController> logger)
        {
            _userService = userService;
            _imageReshapeService = imageReshapeService;
            _logger = logger;
        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user,admin")]
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

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user,admin")]
        [HttpDelete("deleteUser")]
        public async Task<ActionResult<string>> DeleteUser()
        {
            var userName = User.Identity.Name;
            var user = await _userService.GetUserByUserName(userName);
            if (user == null)
            {
                return NotFound("No such user");
            }
            await _userService.DeleteUser(user.Id);
            return Ok($"User {userName} was deleted from system");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user,admin")]
        [HttpGet("getUserDetails")]
        public async Task<ActionResult<UserDetailsDTO>> GetUserDetails()
        {
            var userName = User.Identity.Name;
            var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Guid userId = new Guid(userIdStr);
            var user = await _userService.GetUserByID(userId);
            
            if (user != null)
            {
                UserDetailsDTO userDetails = await _userService.GetUserDetails(userId);
                if(userDetails != null)
                    return Ok(userDetails);
                return NotFound($"User {user.Id} does not have any details");
            }

            return NotFound("Such user doewsnt exists");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user,admin")]
        [HttpDelete("deleteUserDetails")]
        public async Task<ActionResult<string>> DeleteUserDetails()
        {
            var userName = User.Identity.Name;
            var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Guid userId = new Guid(userIdStr);
            var user = await _userService.GetUserByID(userId);

            if (user != null)
            {
                await _userService.DeleteUserDetails(userId);
                return Ok($"User {userName} person details was deleted from system");

            }
            return NotFound("Such user doesnt exists");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user,admin")]
        [HttpPost("postUserDetails")]
        public async Task<ActionResult<string>> PostUserDetails(
            [Required][StringLength(50, MinimumLength = 2)] string firstName,
            [Required][StringLength(50, MinimumLength = 2)] string lastName,
            [Required] long personCode,
            [Required][StringLength(12, MinimumLength = 2)] string phoneNumber,
            [Required][StringLength(50, MinimumLength = 2)] string email)
        {
            if (ModelState.IsValid)
            {
                var userName = User.Identity.Name;
                var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                Guid userId = new Guid(userIdStr);
                var user = await _userService.GetUserByID(userId);
                if (user != null)
                {
                    UserDetailsDTO userDetails = await _userService.CreateUserDetails(userId, firstName, lastName, personCode, phoneNumber, email);
                    if (userDetails != null)
                    {
                        return Ok($"User {userName} details was added");
                    }
                    return BadRequest("Can not user overwrite user details, please use update");

                }

                return NotFound("Such user does not exists");
            }
            return BadRequest("Please check input parameters");

        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user,admin")]
        [HttpPut("updateUserFirstName")]
        public async Task<ActionResult<string>> UpdateUserFirstName([Required][StringLength(50, MinimumLength = 2)] string newFirstName)
        {
            if (ModelState.IsValid)
            {
                var userName = User.Identity.Name;
                var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                Guid userId = new Guid(userIdStr);
                var user = await _userService.GetUserByID(userId);
                if (user != null)
                {
                    await _userService.UpdateUserFirstName(userId, newFirstName);
                    return Ok($"User {userName} first name was changed to '{newFirstName}'");
                }

                return NotFound("Such user does not exists");
            }
            return BadRequest("Please check input parameters, input max length 50");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user,admin")]
        [HttpPut("updateUserLastName")]
        public async Task<ActionResult<string>> UpdateUserLastName([Required][StringLength(50, MinimumLength = 2)] string newLastName)
        {
            if (ModelState.IsValid)
            {
                var userName = User.Identity.Name;
                var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                Guid userId = new Guid(userIdStr);
                var user = await _userService.GetUserByID(userId);
                if (user != null)
                {
                    await _userService.UpdateUserLastName(userId, newLastName);
                    return Ok($"User {userName} last name was changed to '{newLastName}'");
                }

                return NotFound("Such user does not exists");
            }
            return BadRequest("Please check input parameters, input max length 50");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user,admin")]
        [HttpPut("updateUserPersonCode")]
        public async Task<ActionResult<string>> UpdateUserLastName([Required] long newPersonCode)
        {
            if (ModelState.IsValid)
            {
                var userName = User.Identity.Name;
                var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                Guid userId = new Guid(userIdStr);
                var user = await _userService.GetUserByID(userId);
                if (user != null)
                {
                    await _userService.UpdateUserPersonCode(userId, newPersonCode);
                    return Ok($"User {userName} person code was changed");
                }

                return NotFound("Such user does not exists");
            }
            return BadRequest("Please check input parameters, input parameter can't be blank");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user,admin")]
        [HttpPut("updateUserPhoneNumber")]
        public async Task<ActionResult<string>> UpdateUserPhoneNumber([Required][StringLength(12, MinimumLength = 2)] string newPhoneNumber)
        {
            if (ModelState.IsValid)
            {
                var userName = User.Identity.Name;
                var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                Guid userId = new Guid(userIdStr);
                var user = await _userService.GetUserByID(userId);
                if (user != null)
                {
                    await _userService.UpdateUserTelephone(userId, newPhoneNumber);
                    return Ok($"User {userName} telephone number was changed");
                }

                return NotFound("Such user does not exists");
            }
            return BadRequest("Please check input parameters, max string length 12");

        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user,admin")]
        [HttpPut("updateUserEmail")]
        public async Task<ActionResult<string>> UpdateUserEmail([Required][StringLength(50, MinimumLength = 2)] string newEmail)
        {
            if (ModelState.IsValid)
            {
                var userName = User.Identity.Name;
                var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                Guid userId = new Guid(userIdStr);
                var user = await _userService.GetUserByID(userId);
                if (user != null)
                {
                    await _userService.UpdateUserEmail(userId, newEmail);
                    return Ok($"User {userName} telephone number was changed");
                }

                return NotFound("Such user does not exists");
            }
            return BadRequest("Please check input parameters, max string length 50");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user,admin")]
        [HttpGet("getUserAddress")]
        public async Task<ActionResult<UserAddressDTO>> GetUserAddress()
        {
            var userName = User.Identity.Name;
            var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Guid userId = new Guid(userIdStr);
            var user = await _userService.GetUserByID(userId);

            if (user != null)
            {
                UserAddressDTO userAdress = await _userService.GetUserAddress(userId);
                if (userAdress != null)
                    return Ok(userAdress);
                return NotFound($"User {user.Id} does not have any details");
            }

            return NotFound("Such user doesnt exists");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user,admin")]
        [HttpDelete("deleteUserAddress")]
        public async Task<ActionResult<string>> DeleteUserAddress()
        {
            var userName = User.Identity.Name;
            var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Guid userId = new Guid(userIdStr);
            var user = await _userService.GetUserByID(userId);

            if (user != null)
            {
                await _userService.DeleteUserAddress(userId);
                return Ok($"User {userName} address was deleted from system");

            }
            return NotFound("Such user doesnt exists");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user,admin")]
        [HttpPost("addUserAddress")]
        public async Task<ActionResult<string>> AddUserAddress(
            [Required][StringLength(50, MinimumLength = 2)] string country,
            [Required][StringLength(50, MinimumLength = 2)] string city,
            [Required][StringLength(50, MinimumLength = 2)] string street, 
            int houseNumber,
            [StringLength(50, MinimumLength = 2)] string? houseNumberPrefix)
        {
            var userName = User.Identity.Name;
            var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Guid userId = new Guid(userIdStr);
            var user = await _userService.GetUserByID(userId);
            if (user != null)
            {
                var userAdressAdded = await _userService.CreateUserAddress(userId, country, city, street, houseNumber, houseNumberPrefix);
                if (userAdressAdded != null)
                {
                    return Ok($"User {userName} Address was created");
                }
                return BadRequest($"User {userName} Address is already created, use update methods");
            }

            return NotFound("Such user does not exists");
        }
        
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user,admin")]
        [HttpPut("updateUserCountry")]
        public async Task<ActionResult<string>> UpdateUserCountry([Required][StringLength(50, MinimumLength = 2)] string newCountry)
        {
            if (ModelState.IsValid)
            {
                var userName = User.Identity.Name;
                var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                Guid userId = new Guid(userIdStr);
                var user = await _userService.GetUserByID(userId);
                if (user != null)
                {
                    await _userService.UpdateUserAddressCountry(userId, newCountry);
                    return Ok($"User {userName} Country was updated");
                }

                return NotFound("Such user does not exists");
            }
            return BadRequest("Please check input parameters, max string length 50");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user,admin")]
        [HttpPut("updateUserCity")]
        public async Task<ActionResult<string>> UpdateUserCity([Required][StringLength(50, MinimumLength = 2)] string newCity)
        {
            if (ModelState.IsValid)
            {
                var userName = User.Identity.Name;
                var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                Guid userId = new Guid(userIdStr);
                var user = await _userService.GetUserByID(userId);
                if (user != null)
                {
                    await _userService.UpdateUserAddressCity(userId, newCity);
                    return Ok($"User {userName} City was updated");
                }
                return NotFound("Such user does not exists");
            }
            return BadRequest("Please check input parameters, max string length 50");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user,admin")]
        [HttpPut("updateUserStreet")]
        public async Task<ActionResult<string>> UpdateUserStreet([Required][StringLength(100, MinimumLength = 2)] string newStreet)
        {
            if (ModelState.IsValid)
            {
                var userName = User.Identity.Name;
                var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                Guid userId = new Guid(userIdStr);
                var user = await _userService.GetUserByID(userId);
                if (user != null)
                {
                    await _userService.UpdateUserAddressStreet(userId, newStreet);
                    return Ok($"User {userName} City was updated");
                }
                return NotFound("Such user does not exists");
            }
            return BadRequest("Please check input parameters, max string length 10");
        }
        
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user,admin")]
        [HttpPut("updateUserHouseNumber")]
        public async Task<ActionResult<string>> UpdateUserHouseNumber([Required] int newHouseNum)
        {
            if (ModelState.IsValid)
            {
                var userName = User.Identity.Name;
                var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                Guid userId = new Guid(userIdStr);
                var user = await _userService.GetUserByID(userId);
                if (user != null)
                {
                    await _userService.UpdateUserAddressHouseNumber(userId, newHouseNum);
                    return Ok($"User {userName} City was updated");
                }
                return NotFound("Such user does not exists");
            }
            return BadRequest("Please check input parameters, max string length 10");
        }
        
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user,admin")]
        [HttpPut("updateUserHouseNumberPreffix")]
        public async Task<ActionResult<string>> UpdateUserHouseNumberPreffix([Required][StringLength(2, MinimumLength = 1)] string newHousePreffix)
        {
            if (ModelState.IsValid)
            {
                var userName = User.Identity.Name;
                var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                Guid userId = new Guid(userIdStr);
                var user = await _userService.GetUserByID(userId);
                if (user != null)
                {
                    await _userService.UpdateUserAddressHouseNumberPreffix(userId, newHousePreffix);
                    return Ok($"User {userName} City was updated");
                }
                return NotFound("Such user does not exists");
            }
            return BadRequest("Please check input parameters, max string length 2");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user,admin")]
        [HttpPost("uploadUserPhoto")]
        public async Task<ActionResult<string>> UploadUserPhoto([FromForm] ImageUploadRequest imageUploadRequest)
        {
            var userName = User.Identity.Name;
            var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Guid userId = new Guid(userIdStr);
            var user = await _userService.GetUserByID(userId);
            if (user != null)
            {
                using var memoryStream = new MemoryStream();
                {
                    await imageUploadRequest.Image.CopyToAsync(memoryStream);
                    var imageBytes = memoryStream.ToArray();
                    var reshapedImage = await _imageReshapeService.ResizeImage(imageBytes);
                    var userPhotoUploaded = await _userService.UploadUserPhoto(userId, reshapedImage);
                    if (userPhotoUploaded != null)
                    {
                        return Ok($"User {userName} photo was uploaded");
                    }
                    return BadRequest($"User {userName} photo can not be overrided, please delete photo first");
                }
                return BadRequest("Something wrong with picture");
            }
            return NotFound("Such user does not exists");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user,admin")]
        [HttpGet("getUserPhoto")]
        public async Task<ActionResult<string>> GetUserPhoto()
        {
            var userName = User.Identity.Name;
            var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Guid userId = new Guid(userIdStr);
            var user = await _userService.GetUserByID(userId);

            if (user != null)
            {
                UserPhotoDTO userPhoto = await _userService.GetUserPhoto(userId);
                if (userPhoto != null)
                {
                    var img = await _imageReshapeService.DownloadImage(userPhoto.ProfilePic);
                    return Ok(img);
                } 
                return NotFound($"User {user.Id} does not have photo");
            }
            return NotFound("Such user doesnt exists");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user,admin")]
        [HttpDelete("deleteUserPhoto")]
        public async Task<ActionResult<string>> DeleteUserPhoto()
        {
            var userName = User.Identity.Name;
            var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Guid userId = new Guid(userIdStr);
            var user = await _userService.GetUserByID(userId);
            
            if (user != null)
            {
                UserPhotoDTO userPhoto = await _userService.GetUserPhoto(userId);
                if (userPhoto != null)
                {
                    await _userService.DeleteUserPhoto(userId);
                    return Ok($"User {userName} photo was deleted");
                }
                return NotFound($"User {user.Id} does not have photo");
            }
            return NotFound("Such user doesnt exists");
        }
    }
}