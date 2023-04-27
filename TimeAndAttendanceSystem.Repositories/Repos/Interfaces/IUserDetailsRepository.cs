using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeAndAttendanceSystem.Repositories.Models.Entities;

namespace TimeAndAttendanceSystem.Repositories.Repositories.Interfaces
{
    public interface IUserDetailsRepository
    {
        public Task<IEnumerable<UserDetails>> Get();
        public Task<UserDetails> Get(Guid id);
        public Task<UserDetails> GetUserDetailsByUserID(Guid userId);
        public Task AddUserDetails(UserDetails userDetails);
        public Task DeleteUserDetails(UserDetails userDetails);
        public Task UpdateUserFirstName(Guid userId, string newFirstName);
        public Task UpdateUserLastName(Guid userId, string newLastName);
        public Task UpdateUserPersonCode(Guid userId, int newPersonCode);
        public Task UpdateUserEmail(Guid userId, string newEmail);
        public Task UpdateUserTelephone(Guid userId, string newTelephone);
    }
}
