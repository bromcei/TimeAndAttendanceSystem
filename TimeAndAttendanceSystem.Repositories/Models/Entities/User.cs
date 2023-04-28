using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeAndAttendanceSystem.Repositories.Models.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required, MaxLength(32)]
        public string UserName { get; set; }
        [Required]
        public byte[] PasswordHash { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }
        [Required]
        public string UserRole { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public UserDetails? Details { get; set; }
        public UserAddress? Address { get; set; }
        public UserPhoto? Photo { get; set; }

        public User(string userName, byte[] passwordHash, byte[] passwordSalt)
        {
            Id = new Guid();
            UserName = userName;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            UserRole = "user";
            CreatedDate = DateTime.Now;
        }
    }
}
