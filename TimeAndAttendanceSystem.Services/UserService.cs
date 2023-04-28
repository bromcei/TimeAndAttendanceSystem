using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeAndAttendanceSystem.Repositories.Models.Entities;
using TimeAndAttendanceSystem.Repositories.Repos.Interfaces;
using TimeAndAttendanceSystem.Repositories.Repositories.Interfaces;
using TimeAndAttendanceSystem.Services.Interfaces;

namespace TimeAndAttendanceSystem.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserDetailsRepository _userDetailsRepository;
        private readonly IUserAddressRepository _userAddressRepository;
        private readonly IUserPhotosRepository _userPhotosRepository;

        public UserService(
            IUserRepository userRepository,
            IUserDetailsRepository userDetailsRepository,
            IUserAddressRepository userAddressRepository,
            IUserPhotosRepository userPhotosRepository
            )
        {
            _userRepository = userRepository;
            _userDetailsRepository = userDetailsRepository;
            _userAddressRepository = userAddressRepository;
            _userPhotosRepository = userPhotosRepository;
        }

        public async Task<UserAddress> CreateUserAddress(Guid userId, string country, string city, string street, int houseNumber, string? houseNumberPreffix)
        {
            UserAddress userAddress = new UserAddress(userId, country, city, street, houseNumber);
            if (houseNumberPreffix != null)
            {
                userAddress.HouseNumberPreffix = houseNumberPreffix;
            }

            await _userAddressRepository.AddUserAddress(userAddress);
            return userAddress;
        }

        public async Task<UserDetails> CreateUserDetails(Guid userId, string firstName, string lastName, int personCode, string phoneNumber, string email)
        {
            UserDetails userDetails = new UserDetails(userId, firstName, lastName, personCode, phoneNumber, email);
            await _userDetailsRepository.AddUserDetails(userDetails);
            return userDetails;

        }

        public async Task<UserDetails?> DeleteUserDetails(Guid userId)
        {
            UserDetails userDetails = await _userDetailsRepository.GetUserDetailsByUserID(userId);
            if (userDetails != null)
            {
                await _userDetailsRepository.DeleteUserDetails(userDetails);
                return userDetails;
            }
            return null;
        }

        public async Task<UserPhoto?> DeleteUserPhoto(Guid userId)
        {
            UserPhoto userPhoto = await _userPhotosRepository.GetUserPhoto(userId);
            if (userPhoto != null)
            {
                await _userPhotosRepository.DeleteUserPhoto(userPhoto);
                return userPhoto;
            }
            return null;
        }

        public async Task<IEnumerable<User>?> GetAllUsers()
        {
            IEnumerable<User> usersArray = await _userRepository.Get();
            if(usersArray.Count() > 0)
            {
                return usersArray;
            }
            return null;
        }

        public async Task<User?> GetUserByID(Guid userId)
        {
            User user =  await _userRepository.Get(userId);
            if(user != null)
            {
                return user;
            }
            return null;
        }

        public async Task<UserAddress?> UpdateUserAddressCity(Guid userId, string newCity)
        {
            UserAddress userAddress = await _userAddressRepository.GetUserAddressByUserID(userId);
            if(userAddress != null)
            {
                userAddress.City = newCity;
                await _userAddressRepository.UpdateUserAddress(userAddress);
                return userAddress;
            }
            return null;
            
        }

        public async Task<UserAddress?> UpdateUserAddressCountry(Guid userId, string newCountry)
        {
            UserAddress userAddress = await _userAddressRepository.GetUserAddressByUserID(userId);
            if (userAddress != null)
            {
                userAddress.Country = newCountry;
                await _userAddressRepository.UpdateUserAddress(userAddress);
                return userAddress;
            }
            return null;
        }

        public async Task<UserAddress?> UpdateUserAddressHouseNumber(Guid userId, int newHouseNumber)
        {
            UserAddress userAddress = await _userAddressRepository.GetUserAddressByUserID(userId);
            if (userAddress != null)
            {
                userAddress.HouseNumber = newHouseNumber;
                await _userAddressRepository.UpdateUserAddress(userAddress);
                return userAddress;
            }
            return null;
        }

        public Task<UserAddress> UpdateUserAddressHouseNumberPreffix(Guid userId, string newHouseNumberPreffix)
        {
            throw new NotImplementedException();
        }

        public Task<UserAddress> UpdateUserAddressStreet(Guid userId, string newStreet)
        {
            throw new NotImplementedException();
        }

        public Task<UserDetails> UpdateUserEmail(Guid userId, string newEmail)
        {
            throw new NotImplementedException();
        }

        public Task<UserDetails> UpdateUserFirstName(Guid userId, string newFirstName)
        {
            throw new NotImplementedException();
        }

        public Task<UserDetails> UpdateUserLastName(Guid userId, string newLastName)
        {
            throw new NotImplementedException();
        }

        public Task<UserDetails> UpdateUserPersonCode(Guid userId, int newPersonCode)
        {
            throw new NotImplementedException();
        }

        public Task<UserDetails> UpdateUserTelephone(Guid userId, string newTelephone)
        {
            throw new NotImplementedException();
        }

        public Task<UserPhoto> UploadUserPhoto(Guid userId, byte[] profilePic)
        {
            throw new NotImplementedException();
        }
    }
}
