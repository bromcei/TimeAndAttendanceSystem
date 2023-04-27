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
        //private readonly IUserPhotosRepository _userPhotosRepository;
        public UserService(IUserRepository userRepository, IUserDetailsRepository userDetailsRepository) //, IUserPhotosRepository userPhotosRepository)
        {
            _userRepository = userRepository;
            _userDetailsRepository = userDetailsRepository;
         //   _userPhotosRepository = userPhotosRepository;
        }

        public async Task<UserDetails> CreateUserDetails(UserDetails userDetails)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDetails> DeleteUserDetails(UserDetails userDetails)
        {
            throw new NotImplementedException();
        }

        public async Task<UserPhoto> DeleteUserPhoto(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userRepository.Get();
        }

        public async Task<User> GetUserByID(Guid userId)
        {
            return await _userRepository.Get(userId);
        }

        public async Task<UserDetails> UpdateUserAddress(Guid userId, string newAddress)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDetails> UpdateUserEmail(Guid userId, string newEmail)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDetails> UpdateUserFirstName(Guid userId, string newFirstName)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDetails> UpdateUserLastName(Guid userId, string newLastName)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDetails> UpdateUserPersonCode(Guid userId, int newPersonCode)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDetails> UpdateUserTelephone(Guid userId, string newTelephone)
        {
            throw new NotImplementedException();
        }

        public async Task<UserPhoto> UploadUserPhoto(UserPhoto userPhoto)
        {
            throw new NotImplementedException();
        }
    }
}
