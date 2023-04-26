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
        [Required]
        public byte[] Password{ get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }
        [Required]
        public string UserRole { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public UserDetails Details { get; set; }
        public UserPhoto Photo { get; set; }

        public User(byte[] password, byte[] passwordSalt, DateTime createdDate, UserDetails? details, UserPhoto? photo)
        {
            Id = new Guid();
            Password = password;
            PasswordSalt = passwordSalt;
            UserRole = "user";
            CreatedDate = DateTime.Now;
            Details = details;
            Photo = photo;
        }
    }
}
