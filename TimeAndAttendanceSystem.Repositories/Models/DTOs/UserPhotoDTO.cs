using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeAndAttendanceSystem.Repositories.Models.Entities;

namespace TimeAndAttendanceSystem.Repositories.Models.DTOs
{
    public class UserPhotoDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public byte[]? ProfilePic { get; set; }
    }
}
