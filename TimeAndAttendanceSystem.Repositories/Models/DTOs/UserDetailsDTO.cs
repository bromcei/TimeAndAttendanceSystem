using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeAndAttendanceSystem.Repositories.Models.Entities;

namespace TimeAndAttendanceSystem.Repositories.Models.DTOs
{
    public class UserDetailsDTO
    {
        public UserDetails UserDetails { get; set; }
        public UserPhoto UserPhoto { get; set; }
        public UserDetailsDTO(UserDetails userDetails, UserPhoto userPhoto)
        {
            UserDetails = userDetails;
            UserPhoto = userPhoto;
        }
    }
}
