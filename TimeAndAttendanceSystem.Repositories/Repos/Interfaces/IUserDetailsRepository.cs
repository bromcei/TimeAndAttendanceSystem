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
        public Task<IEnumerable<UserDetails>?> Get();
        public Task<UserDetails?> Get(Guid id);
        public Task<UserDetails?> GetUserDetailsByUserID(Guid userId);
        public Task AddUserDetails(UserDetails userDetails);
        public Task DeleteUserDetails(UserDetails userDetails);
        public Task UpdateUserDetails(UserDetails userDetails);
    }
}
