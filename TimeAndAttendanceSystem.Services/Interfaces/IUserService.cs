using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeAndAttendanceSystem.Repositories.Models.DTOs;
using TimeAndAttendanceSystem.Repositories.Models.Entities;

namespace TimeAndAttendanceSystem.Services.Interfaces
{
    public interface IUserService
    {
        public Task<UserDTO?> GetUserByID(Guid userId);
        public Task<UserDTO?> GetUserByUserName(string username);
        public Task<UserDetailsDTO?> GetUserDetails(string username);
        public Task<UserPhotoDTO?> GetUserPhoto(string username);
        public Task<UserAddressDTO?> GetUserAddress(string username);
        public Task<IEnumerable<UserDTO>?> GetAllUsers();
        public Task<UserDetailsDTO?> CreateUserDetails(Guid userId, string firstName, string lastName, long personCode, string phoneNumber, string email);
        public Task<UserAddressDTO?> CreateUserAddress(Guid userId, string country, string city, string street, int houseNumber, string? houseNumberPrefix);
        public Task<UserPhotoDTO?> UploadUserPhoto(Guid userId, byte[] profilePic);
        public Task DeleteUserPhoto(Guid userId);
        public Task DeleteUserDetails(Guid userId);
        public Task<UserDetailsDTO?> UpdateUserFirstName(Guid userId, string newFirstName);
        public Task<UserDetailsDTO?> UpdateUserLastName(Guid userId, string newLastName);
        public Task<UserDetailsDTO?> UpdateUserPersonCode(Guid userId, long newPersonCode);
        public Task<UserDetailsDTO?> UpdateUserEmail(Guid userId, string newEmail);
        public Task<UserDetailsDTO?> UpdateUserTelephone(Guid userId, string newTelephone);
        public Task<UserAddressDTO?> UpdateUserAddressCountry(Guid userId, string newCountry);
        public Task<UserAddressDTO?> UpdateUserAddressCity(Guid userId, string newCity);
        public Task<UserAddressDTO?> UpdateUserAddressStreet(Guid userId, string newStreet);
        public Task<UserAddressDTO?> UpdateUserAddressHouseNumber(Guid userId, int newHouseNumber);
        public Task<UserAddressDTO?> UpdateUserAddressHouseNumberPreffix(Guid userId, string newHouseNumberPreffix);
    }
}
