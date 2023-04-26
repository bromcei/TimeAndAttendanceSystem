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
        private readonly IUserPhotosRepository _userPhotosRepository;
        public UserService(IUserRepository userRepository, IUserDetailsRepository userDetailsRepository, IUserPhotosRepository userPhotosRepository)
        {
            _userRepository = userRepository;
            _userDetailsRepository = userDetailsRepository;
            _userPhotosRepository = userPhotosRepository;
        }

        public Task<User> CreateNewUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<UserDetails> CreateUserDetails(UserDetails userDetails)
        {
            throw new NotImplementedException();
        }

        public Task<UserDetails> DeleteUserDetails(UserDetails userDetails)
        {
            throw new NotImplementedException();
        }

        public Task<UserPhoto> DeleteUserPhoto(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<UserDetails> UpdateUserAddress(Guid userId, string newAddress)
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

        public Task<UserPhoto> UploadUserPhoto(UserPhoto userPhoto)
        {
            throw new NotImplementedException();
        }
    }
}
