using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeAndAttendanceSystem.Services.Interfaces
{
    public interface IJwtService
    {
        public Task<string> GetJwtToken(string username, string role);
    }
}
