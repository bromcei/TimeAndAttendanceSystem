using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeAndAttendanceSystem.Repositories.Models.Entities
{
    public class UserPhoto
    {
        public Guid Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public User? User { get; set; }
        public byte[] ProfilePic { get; set; }
        public UserPhoto( Guid userId, byte[] profilePic)
        {
            Id = new Guid();
            UserId = userId;
            ProfilePic = profilePic;
        }
    }
}
