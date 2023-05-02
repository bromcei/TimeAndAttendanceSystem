using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Security.Claims;
using TimeAndAttendanceSystem.Controllers;
using TimeAndAttendanceSystem.Repositories.Models.DTOs;
using TimeAndAttendanceSystem.Repositories.Models.Entities;
using TimeAndAttendanceSystem.Services.Interfaces;
using TimeAndAttendanceSystem.Services.Requests;
using TimeAndAttendanceSystem.Services.Services;

namespace TimeAndAttendanceSystem.API.Controllers
{
    public class SuperAdminController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IImageReshapeService _imageReshapeService;
        private readonly ILogger<UserController> _logger;


        public SuperAdminController(IUserService userService, IImageReshapeService imageReshapeService, ILogger<UserController> logger)
        {
            _userService = userService;
            _imageReshapeService = imageReshapeService; 
            _logger = logger;
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [HttpGet("getUserById")]
        public async Task<ActionResult<User?>> GetUserById(Guid userId)
        {
            var user = await _userService.GetUserByID(userId);
            if (user == null)
            {
                return NotFound("No data received");
            }
            return Ok(user);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [HttpGet("getUser")]
        public async Task<ActionResult<User>> GetUser(Guid userId)
        {
            var user = await _userService.GetUserByID(userId);
            if (user == null)
            {
                return NotFound("No data received");
            }
            return Ok(user);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [HttpDelete("deleteUser")]
        public async Task<ActionResult<string>> DeleteUser(Guid userId)
        {
            var user = await _userService.DeleteUser(userId);
            if (user != null)
            {
                
                return Ok($"User {userId} was deleted from system");
            }
            return NotFound("No such user");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [HttpGet("getUserDetails")]
        public async Task<ActionResult<UserDetailsDTO>> GetUserDetails(Guid userId)
        {
            var userDetails = await _userService.GetUserDetails(userId);
            if (userDetails != null)
            {
                return Ok(userDetails);                
            }

            return NotFound("Such user doesnt have any details");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [HttpDelete("deleteUserDetails")]
        public async Task<ActionResult<string>> DeleteUserDetails(Guid userId)
        {
            var userDetails = await _userService.DeleteUserDetails(userId);
            if (userDetails != null)
            {                
                return Ok($"User {userId} person details was deleted from system");
            }
            return NotFound("Such entity doesnt exists");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [HttpPost("postUserDetails")]
        public async Task<ActionResult<string>> PostUserDetails(Guid userId, UserAddDetailsDto userAddDetailsDto)
        {
            UserDetailsDTO? userDetails = await _userService.CreateUserDetails(userId, userAddDetailsDto);
            if (userDetails != null)
            {
                return Ok($"User {userDetails.UserId} details was added");
            }
            return NotFound("Such user does not exists");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [HttpPut("updateUserFirstName")]
        public async Task<ActionResult<string>> UpdateUserFirstName(
            [Required] Guid userId, 
            [Required][StringLength(50, MinimumLength = 2)] string newFirstName)
        {
            if (ModelState.IsValid)
            {
                var userDetails = await _userService.UpdateUserFirstName(userId, newFirstName);
                if (userDetails != null)
                {                    
                    return Ok($"User {userId} first name was changed to '{newFirstName}'");
                }
                return NotFound("Such user does not exists");
            }
            return BadRequest("Please check input parameters, input max length 50");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [HttpPut("updateUserLastName")]
        public async Task<ActionResult<string>> UpdateUserLastName(
            [Required] Guid userId,
            [Required][StringLength(50, MinimumLength = 2)] string newLastName)
        {
            if (ModelState.IsValid)
            {
                var userDetails = _userService.UpdateUserLastName(userId, newLastName);
                if (userDetails != null)
                {
                    return Ok($"User {userId} last name was changed to '{newLastName}'");
                }
                return NotFound("Such user does not exists");
            }
            return BadRequest("Please check input parameters, input max length 50");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [HttpPut("updateUserPersonCode")]
        public async Task<ActionResult<string>> UpdateUserLastName([Required] Guid userId, [Required] long newPersonCode)
        {
            if (ModelState.IsValid)
            {
                var userDetails = await _userService.UpdateUserPersonCode(userId, newPersonCode);
                if (userDetails != null)
                {                    
                    return Ok($"User {userId} person code was changed");
                }

                return NotFound("Such user does not exists");
            }
            return BadRequest("Please check input parameters, input parameter can't be blank");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [HttpPut("updateUserPhoneNumber")]
        public async Task<ActionResult<string>> UpdateUserPhoneNumber(
            [Required] Guid userId,
            [Required][StringLength(12, MinimumLength = 2)] string newPhoneNumber)
        {
            if (ModelState.IsValid)
            {
                var userDetails = await _userService.UpdateUserTelephone(userId, newPhoneNumber);
                if (userDetails != null)
                {                    
                    return Ok($"User {userId} telephone number was changed");
                }
                return NotFound("Such user does not exists");
            }
            return BadRequest("Please check input parameters, max string length 12");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [HttpPut("updateUserEmail")]
        public async Task<ActionResult<string>> UpdateUserEmail(
            [Required] Guid userId,
            [Required][StringLength(50, MinimumLength = 2)] string newEmail)
        {
            if (ModelState.IsValid)
            {
                var userDetails = await _userService.UpdateUserEmail(userId, newEmail);
                if (userDetails != null)
                {                    
                    return Ok($"User {userId} telephone number was changed");
                }
                return NotFound("Such user does not exists");
            }
            return BadRequest("Please check input parameters, max string length 50");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [HttpGet("getUserAddress")]
        public async Task<ActionResult<UserAddressDTO>> GetUserAddress([Required] Guid userId)
        {
            var userAddress = await _userService.GetUserAddress(userId);

            if (userAddress != null)
            {
                return Ok(userAddress);                
            }
            return NotFound($"User {userId} does not have any details");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [HttpDelete("deleteUserAddress")]
        public async Task<ActionResult<string>> DeleteUserAddress([Required] Guid userId)
        {
            var userAddress = await _userService.DeleteUserAddress(userId);
            if (userAddress != null)
            {
                return Ok($"User {userId} address was deleted from system");
            }
            return NotFound("Such entity doesnt exists");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [HttpPost("addUserAddress")]
        public async Task<ActionResult<string>> AddUserAddress(Guid userId, UserAddAddressDTO userAddAddressDTO)
        {           
            var userAdressAdded = await _userService.CreateUserAddress(userId, userAddAddressDTO);
            if (userAdressAdded != null)
            {
                return Ok($"User {userId} Address was created");
            }
            return BadRequest($"User {userId} Address is already created or user doesnt exists");          
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [HttpPut("updateUserCountry")]
        public async Task<ActionResult<string>> UpdateUserCountry(
            [Required] Guid userId,
            [Required][StringLength(50, MinimumLength = 2)] string newCountry)
        {
            if (ModelState.IsValid)
            {
                var userAddress = await _userService.UpdateUserAddressCountry(userId, newCountry);
                if (userAddress != null)
                {                    
                    return Ok($"User {userId} Country was updated");
                }
                return BadRequest("Such user does not exists or address is already uploaded");
            }
            return BadRequest("Please check input parameters, max string length 50");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [HttpPut("updateUserCity")]
        public async Task<ActionResult<string>> UpdateUserCity(
            [Required] Guid userId,
            [Required][StringLength(50, MinimumLength = 2)] string newCity)
        {
            if (ModelState.IsValid)
            {
                var userAdress = await _userService.UpdateUserAddressCity(userId, newCity);
                if (userAdress != null)
                {
                    return Ok($"User {userId} City was updated");
                }
                return NotFound("Such user does not exists");
            }
            return BadRequest("Please check input parameters, max string length 50");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [HttpPut("updateUserStreet")]
        public async Task<ActionResult<string>> UpdateUserStreet(
            [Required] Guid userId,
            [Required][StringLength(100, MinimumLength = 2)] string newStreet)
        {
            if (ModelState.IsValid)
            {
                var userAddress = await _userService.UpdateUserAddressStreet(userId, newStreet);
                if (userAddress != null)
                {                    
                    return Ok($"User {userId} City was updated");
                }
                return NotFound("Such user does not exists");
            }
            return BadRequest("Please check input parameters, max string length 10");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [HttpPut("updateUserHouseNumber")]
        public async Task<ActionResult<string>> UpdateUserHouseNumber(
            [Required] Guid userId,
            [Required] int newHouseNum)
        {
            if (ModelState.IsValid)
            {
                var userAddress = await _userService.UpdateUserAddressHouseNumber(userId, newHouseNum);
                if (userAddress != null)
                {
                    
                    return Ok($"User {userId} City was updated");
                }
                return NotFound("Such user does not exists");
            }
            return BadRequest("Please check input parameters, max string length 10");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [HttpPut("updateUserHouseNumberPreffix")]
        public async Task<ActionResult<string>> UpdateUserHouseNumberPreffix(
            [Required] Guid userId,
            [Required][StringLength(2, MinimumLength = 1)] string newHousePreffix)
        {
            if (ModelState.IsValid)
            {
                var userAddress = await _userService.UpdateUserAddressHouseNumberPreffix(userId, newHousePreffix);
                if (userAddress != null)
                {                    
                    return Ok($"User {userId} City was updated");
                }
                return NotFound("Such user does not exists");
            }
            return BadRequest("Please check input parameters, max string length 2");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [HttpPost("uploadUserPhoto")]
        public async Task<ActionResult<string>> UploadUserPhoto(
            [Required] Guid userId,
            [FromForm] ImageUploadRequest imageUploadRequest)
        {
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
                        return Ok($"User {userId} photo was uploaded");
                    }
                    return BadRequest($"User {userId} photo can not be overrided, please delete photo first");
                }
            }

            return NotFound("Such user does not exists");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [HttpGet("getUserPhoto")]
        public async Task<ActionResult<string>> GetUserPhoto([Required] Guid userId)
        {
            var userPhoto = await _userService.GetUserPhoto(userId);
            if (userPhoto != null)
            {
                var img = await _imageReshapeService.DownloadImage(userPhoto.ProfilePic);
                return Ok(img);
            }

            return NotFound("Such entity doesnt exists");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [HttpDelete("deleteUserPhoto")]
        public async Task<ActionResult<string>> DeleteUserPhoto([Required] Guid userId)
        {
            var userPhoto = await _userService.GetUserPhoto(userId);
            if (userPhoto != null)
            {
                return Ok($"User {userId} photo was deleted");
            }
            return NotFound("Such entity doesnt exists");
        }
    }
}
