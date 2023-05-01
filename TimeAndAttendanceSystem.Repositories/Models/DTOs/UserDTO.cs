using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeAndAttendanceSystem.Repositories.Models.DTOs
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string? UserName { get; set; }
        public string? UserRole { get; set; }
        public byte[]? Password { get; set; }
    }
}
