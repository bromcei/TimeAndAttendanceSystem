﻿using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeAndAttendanceSystem.Repositories.Models.DTOs;
using TimeAndAttendanceSystem.Repositories.Models.Entities;
using TimeAndAttendanceSystem.Repositories.Repos.Interfaces;
using TimeAndAttendanceSystem.Repositories.Repositories.Interfaces;
using TimeAndAttendanceSystem.Services.Interfaces;

namespace TimeAndAttendanceSystem.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserDetailsRepository _userDetailsRepository;
        private readonly IUserAddressRepository _userAddressRepository;
        private readonly IUserPhotosRepository _userPhotosRepository;
        private readonly IMapper _mapper;

        public UserService(
            IUserRepository userRepository,
            IUserDetailsRepository userDetailsRepository,
            IUserAddressRepository userAddressRepository,
            IUserPhotosRepository userPhotosRepository,
            IMapper mapper
            )
        {
            _userRepository = userRepository;
            _userDetailsRepository = userDetailsRepository;
            _userAddressRepository = userAddressRepository;
            _userPhotosRepository = userPhotosRepository;
            _mapper = mapper;
        }

        public async Task<UserAddressDTO?> CreateUserAddress(Guid userId, UserAddAddressDTO userAddAddressDTO)
        {
            User? user = await _userRepository.Get(userId);
            UserAddress? userAddressCheck = await _userAddressRepository.GetUserAddressByUserID(userId);
            if (user != null && userAddressCheck == null)
            {
                UserAddress userAddress = new UserAddress();
                _mapper.Map(userAddAddressDTO, userAddress);
                userAddress.UserId = userId;
                await _userAddressRepository.AddUserAddress(userAddress);
                UserAddressDTO userAddressDTO = _mapper.Map<UserAddressDTO>(userAddress);
                return userAddressDTO;
            }
            return null;

        }

        public async Task<UserDetailsDTO?> CreateUserDetails(Guid userId, UserAddDetailsDto userAddDetailsDto)
        {

            User? user = await _userRepository.Get(userId);
            UserDetails? userDetailsCheck = await _userDetailsRepository.GetUserDetailsByUserID(userId);
            if (user != null && userDetailsCheck == null)
            {
                UserDetails userDetails = new UserDetails();
                _mapper.Map(userAddDetailsDto, userDetails);
                userDetails.UserId = userId;    
                var addedUser = await _userDetailsRepository.AddUserDetails(userDetails);
                UserDetailsDTO userDetailsDTO = _mapper.Map<UserDetailsDTO>(addedUser);
                return userDetailsDTO;
            }
            return null;
        }

        public async Task<UserDTO?> DeleteUser(Guid userId)
        {
            User? user = await _userRepository.Get(userId);
            if (user != null)
            {
                await _userRepository.DeleteUser(user);
                return _mapper.Map<UserDTO>(user);
            }
            return null;
        }

        public async Task<UserAddressDTO?> DeleteUserAddress(Guid userId)
        {
            UserAddress? userAddress = await _userAddressRepository.GetUserAddressByUserID(userId);
            if (userAddress != null)
            {
                await _userAddressRepository.DeleteUserAddress(userAddress);
                return _mapper.Map<UserAddressDTO>(userAddress);
            }
            return null;
        }

        public async Task<UserDetailsDTO?> DeleteUserDetails(Guid userId)
        {
            UserDetails? userDetails = await _userDetailsRepository.GetUserDetailsByUserID(userId);
            if (userDetails != null)
            {
                await _userDetailsRepository.DeleteUserDetails(userDetails);
                return _mapper.Map<UserDetailsDTO>(userDetails);
            }
            return null;
        }

        public async Task<UserPhotoDTO?> DeleteUserPhoto(Guid userId)
        {
            UserPhoto? userPhoto = await _userPhotosRepository.GetUserPhoto(userId);
            if (userPhoto != null)
            {
                await _userPhotosRepository.DeleteUserPhoto(userPhoto);
                return _mapper.Map<UserPhotoDTO>(userPhoto);
            }
            return null;
        }

        public async Task<IEnumerable<UserDTO>?> GetAllUsers()
        {
            IEnumerable<User> usersArray = await _userRepository.Get();
            if (usersArray.Count() > 0)
            {
                IEnumerable<UserDTO> usersDTOArray = usersArray.Select(user => _mapper.Map<UserDTO>(user));
                return usersDTOArray;
            }
            return null;
        }

        public async Task<UserAddressDTO?> GetUserAddress(Guid userId)
        {
            User? user = await _userRepository.Get(userId);
            if (user != null)
            {
                UserAddress? userAddress = await _userAddressRepository.GetUserAddressByUserID(user.Id);
                if (userAddress != null)
                {
                    UserAddressDTO userAddressDTO = _mapper.Map<UserAddressDTO>(userAddress);
                    return userAddressDTO;
                }
                return null;
            }
            return null;
        }

        public async Task<UserDTO?> GetUserByID(Guid userId)
        {
            User? user = await _userRepository.Get(userId);
            if (user != null)
            {
                UserDTO userDTO = _mapper.Map<UserDTO>(user);
                return userDTO;
            }
            return null;
        }

        public async Task<UserDTO?> GetUserByUserName(string username)
        {
            User? user = await _userRepository.Get(username);
            UserDTO userDTO = _mapper.Map<UserDTO>(user);

            return userDTO;
        }

        public async Task<UserDetailsDTO?> GetUserDetails(Guid userId)
        {
            User? user = await _userRepository.Get(userId);
            if (user != null)
            {
                UserDetails? userDetails = await _userDetailsRepository.GetUserDetailsByUserID(user.Id);
                if (userDetails != null)
                {
                    UserDetailsDTO userDetailsDTO = _mapper.Map<UserDetailsDTO>(userDetails);
                    return userDetailsDTO;
                }
                return null;
            }
            return null;
        }

        public async Task<UserPhotoDTO?> GetUserPhoto(Guid userId)
        {
            User? user = await _userRepository.Get(userId);
            if (user != null)
            {
                UserPhoto? userPhoto = await _userPhotosRepository.GetUserPhoto(user.Id);
                if (userPhoto != null)
                {
                    UserPhotoDTO userPhotoDTO = _mapper.Map<UserPhotoDTO>(userPhoto);
                    return userPhotoDTO;
                }
                return null;
            }
            return null;
        }

        public async Task<UserAddressDTO?> UpdateUserAddressCity(Guid userId, string newCity)
        {
            UserAddress? userAddress = await _userAddressRepository.GetUserAddressByUserID(userId);
            if (userAddress != null)
            {
                userAddress.City = newCity;
                await _userAddressRepository.UpdateUserAddress(userAddress);
                UserAddressDTO userAddressDTO = _mapper.Map<UserAddressDTO>(userAddress);
                return userAddressDTO;
            }
            return null;

        }

        public async Task<UserAddressDTO?> UpdateUserAddressCountry(Guid userId, string newCountry)
        {
            UserAddress? userAddress = await _userAddressRepository.GetUserAddressByUserID(userId);
            if (userAddress != null)
            {
                userAddress.Country = newCountry;
                await _userAddressRepository.UpdateUserAddress(userAddress);
                UserAddressDTO userAddressDTO = _mapper.Map<UserAddressDTO>(userAddress);
                return userAddressDTO;
            }
            return null;
        }

        public async Task<UserAddressDTO?> UpdateUserAddressHouseNumber(Guid userId, int newHouseNumber)
        {
            UserAddress? userAddress = await _userAddressRepository.GetUserAddressByUserID(userId);
            if (userAddress != null)
            {
                userAddress.HouseNumber = newHouseNumber;
                await _userAddressRepository.UpdateUserAddress(userAddress);
                UserAddressDTO userAddressDTO = _mapper.Map<UserAddressDTO>(userAddress);
                return userAddressDTO;
            }
            return null;
        }

        public async Task<UserAddressDTO?> UpdateUserAddressHouseNumberPreffix(Guid userId, string newHouseNumberPreffix)
        {
            UserAddress? userAddress = await _userAddressRepository.GetUserAddressByUserID(userId);
            if (userAddress != null)
            {
                userAddress.HouseNumberPreffix = newHouseNumberPreffix;
                await _userAddressRepository.UpdateUserAddress(userAddress);
                UserAddressDTO userAddressDTO = _mapper.Map<UserAddressDTO>(userAddress);
                return userAddressDTO;
            }
            return null;
        }

        public async Task<UserAddressDTO?> UpdateUserAddressStreet(Guid userId, string newStreet)
        {
            UserAddress? userAddress = await _userAddressRepository.GetUserAddressByUserID(userId);
            if (userAddress != null)
            {
                userAddress.Street = newStreet;
                await _userAddressRepository.UpdateUserAddress(userAddress);
                UserAddressDTO userAddressDTO = _mapper.Map<UserAddressDTO>(userAddress);
                return userAddressDTO;
            }
            return null;
        }

        public async Task<UserDetailsDTO?> UpdateUserEmail(Guid userId, string newEmail)
        {
            UserDetails? userDetails = await _userDetailsRepository.GetUserDetailsByUserID(userId);
            if (userDetails != null)
            {
                userDetails.Email = newEmail;
                await _userDetailsRepository.UpdateUserDetails(userDetails);
                UserDetailsDTO userDetailsDTO = _mapper.Map<UserDetailsDTO>(userDetails);
                return userDetailsDTO;
            }
            return null;
        }

        public async Task<UserDetailsDTO?> UpdateUserFirstName(Guid userId, string newFirstName)
        {
            UserDetails? userDetails = await _userDetailsRepository.GetUserDetailsByUserID(userId);
            if (userDetails != null)
            {
                userDetails.FirstName = newFirstName;
                await _userDetailsRepository.UpdateUserDetails(userDetails);
                UserDetailsDTO userDetailsDTO = _mapper.Map<UserDetailsDTO>(userDetails);
                return userDetailsDTO;
            }
            return null;
        }

        public async Task<UserDetailsDTO?> UpdateUserLastName(Guid userId, string newLastName)
        {
            UserDetails? userDetails = await _userDetailsRepository.GetUserDetailsByUserID(userId);
            if (userDetails != null)
            {
                userDetails.LastName = newLastName;
                await _userDetailsRepository.UpdateUserDetails(userDetails);
                UserDetailsDTO userDetailsDTO = _mapper.Map<UserDetailsDTO>(userDetails);
                return userDetailsDTO;
            }
            return null;
        }

        public async Task<UserDetailsDTO?> UpdateUserPersonCode(Guid userId, long newPersonCode)
        {
            UserDetails? userDetails = await _userDetailsRepository.GetUserDetailsByUserID(userId);
            if (userDetails != null)
            {
                userDetails.PersonCode = newPersonCode;
                await _userDetailsRepository.UpdateUserDetails(userDetails);
                UserDetailsDTO userDetailsDTO = _mapper.Map<UserDetailsDTO>(userDetails);
                return userDetailsDTO;
            }
            return null;
        }

        public async Task<UserDetailsDTO?> UpdateUserTelephone(Guid userId, string newTelephone)
        {
            UserDetails? userDetails = await _userDetailsRepository.GetUserDetailsByUserID(userId);
            if (userDetails != null)
            {
                userDetails.PhoneNumber = newTelephone;
                await _userDetailsRepository.UpdateUserDetails(userDetails);
                UserDetailsDTO userDetailsDTO = _mapper.Map<UserDetailsDTO>(userDetails);
                return userDetailsDTO;
            }
            return null;
        }

        public async Task<UserPhotoDTO?> UploadUserPhoto(Guid userId, byte[] profilePic)
        {
            User? user = await _userRepository.Get(userId);
            UserPhoto? userPhotoCheck = await _userPhotosRepository.GetUserPhoto(userId);
            if (user != null && userPhotoCheck == null)
            {
                UserPhoto userPhoto = new UserPhoto(userId, profilePic);
                await _userPhotosRepository.AddUserPhoto(userPhoto);
                UserPhotoDTO userPhotoDTO = _mapper.Map<UserPhotoDTO>(userPhoto);
                return userPhotoDTO;
            }
            return null;
        }
    }
}
