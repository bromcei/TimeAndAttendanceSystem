using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TimeAndAttendanceSystem.Repositories.Models.Entities;
using TimeAndAttendanceSystem.Repositories.Repositories.Interfaces;
using TimeAndAttendanceSystem.Services.Interfaces;

namespace TimeAndAttendanceSystem.Services
{
    public class AuthenticattionService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        public AuthenticattionService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> CreateUser(string userName, string password)
        {
            byte[] passwordSalt;
            byte[] passwordHash;
            using (var hmacHash = new HMACSHA512())
            {
                passwordSalt = hmacHash.Key;
                passwordHash = hmacHash.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
            User user = new User(userName, passwordHash, passwordSalt);
            await _userRepository.CreateUser(user);
            return user;
        }

        public async Task<bool> Login(string userName, string password)
        {
            var user = await _userRepository.Get(userName);
            if (VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt) && user != null)
            {
                return true;
            }       
            return false;
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmacHash = new HMACSHA512(passwordSalt);
            var computedHash = hmacHash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            return computedHash.SequenceEqual(passwordHash);
        }
    }
}
