using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeAndAttendanceSystem.Repositories.Models.Entities;

namespace TimeAndAttendanceSystem.Repositories.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> Get();
        public Task<User> Get(Guid id);
        public Task<User> Get(string userName);
        public Task CreateUser(User user);
        public Task DeleteUser(User user);
        public Task UpdateUserPassword(Guid userId, byte[] newPassword);


    }
}
