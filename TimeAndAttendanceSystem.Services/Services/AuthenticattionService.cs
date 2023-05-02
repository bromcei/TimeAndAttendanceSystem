using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TimeAndAttendanceSystem.Repositories.Models.DTOs;
using TimeAndAttendanceSystem.Repositories.Models.Entities;
using TimeAndAttendanceSystem.Repositories.Repositories.Interfaces;
using TimeAndAttendanceSystem.Services.Interfaces;

namespace TimeAndAttendanceSystem.Services.Services
{
    public class AuthenticattionService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public AuthenticattionService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;

        }
        public async Task<UserDTO?> CreateUser(string userName, string password)
        {
            byte[] passwordSalt;
            byte[] passwordHash;
            if (await _userRepository.Get(userName) == null && password.Count() > 0)
            {
                using (var hmacHash = new HMACSHA512())
                {
                    passwordSalt = hmacHash.Key;
                    passwordHash = hmacHash.ComputeHash(Encoding.UTF8.GetBytes(password));
                }
                User? user = new User(userName, passwordHash, passwordSalt);
                if(user != null)
                {
                    await _userRepository.CreateUser(user);

                    UserDTO userDTO = _mapper.Map<UserDTO>(user);
                    return userDTO;
                }
                return null;

            }
            return null;

        }

        public async Task<bool> Login(string userName, string password)
        {
            User? user = await _userRepository.Get(userName);
            if (user != null)
            {
                return VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt);
            }
            return false;
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmacHash = new HMACSHA512(passwordSalt);
            var computedHash = hmacHash.ComputeHash(Encoding.UTF8.GetBytes(password));

            return computedHash.SequenceEqual(passwordHash);
        }
    }
}
