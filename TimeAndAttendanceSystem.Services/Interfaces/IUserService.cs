using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeAndAttendanceSystem.Repositories.Models.Entities;

namespace TimeAndAttendanceSystem.Services.Interfaces
{
    public interface IUserService
    {
        public Task<User?> GetUserByID(Guid userId);
        public Task<User?> GetUserByUserName(string username);
        public Task<IEnumerable<User>?> GetAllUsers();
        public Task<UserDetails?> CreateUserDetails(Guid userId, string firstName, string lastName, int personCode, string phoneNumber, string email);
        public Task<UserAddress?> CreateUserAddress(Guid userId, string country, string city, string street, int houseNumber, string? houseNumberPrefix);
        public Task<UserPhoto?> UploadUserPhoto(Guid userId, byte[] profilePic);
        public Task<UserPhoto?> DeleteUserPhoto(Guid userId);
        public Task<UserDetails?> DeleteUserDetails(Guid userId);
        public Task<UserDetails?> UpdateUserFirstName(Guid userId, string newFirstName);
        public Task<UserDetails?> UpdateUserLastName(Guid userId, string newLastName);
        public Task<UserDetails?> UpdateUserPersonCode(Guid userId, int newPersonCode);
        public Task<UserDetails?> UpdateUserEmail(Guid userId, string newEmail);
        public Task<UserDetails?> UpdateUserTelephone(Guid userId, string newTelephone);
        public Task<UserAddress?> UpdateUserAddressCountry(Guid userId, string newCountry);
        public Task<UserAddress?> UpdateUserAddressCity(Guid userId, string newCity);
        public Task<UserAddress?> UpdateUserAddressStreet(Guid userId, string newStreet);
        public Task<UserAddress?> UpdateUserAddressHouseNumber(Guid userId, int newHouseNumber);
        public Task<UserAddress?> UpdateUserAddressHouseNumberPreffix(Guid userId, string newHouseNumberPreffix);
    }
}
