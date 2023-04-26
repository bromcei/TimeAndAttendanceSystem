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
        public Task<User> CreateNewUser(User user);
        public Task<UserDetails> CreateUserDetails(UserDetails userDetails);
        public Task<UserPhoto> UploadUserPhoto(UserPhoto userPhoto);
        public Task<UserPhoto> DeleteUserPhoto(Guid userId);
        public Task<UserDetails> DeleteUserDetails(UserDetails userDetails);
        public Task<UserDetails> UpdateUserFirstName(Guid userId, string newFirstName);
        public Task<UserDetails> UpdateUserLastName(Guid userId, string newLastName);
        public Task<UserDetails> UpdateUserPersonCode(Guid userId, int newPersonCode);
        public Task<UserDetails> UpdateUserEmail(Guid userId, string newEmail);
        public Task<UserDetails> UpdateUserTelephone(Guid userId, string newTelephone);
        public Task<UserDetails> UpdateUserAddress(Guid userId, string newAddress);
    }
}
