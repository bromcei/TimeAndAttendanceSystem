using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeAndAttendanceSystem.Repositories.Models.Entities;

namespace TimeAndAttendanceSystem.Services.Interfaces
{
    public interface IAuthenticationService
    {
        public Task<User> CreateUser(string userName, string password);
        public Task<bool> Login(string userName, string password);

    }
}
