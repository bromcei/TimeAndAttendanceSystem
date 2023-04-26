using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeAndAttendanceSystem.Repositories.Models.Entities
{
    public class UserDetails
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid UserId { get; set; }    
        [Required]
        public User User { get; set; }
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        public int PersonCode { get; set; }
        [Required, MaxLength(12)]
        public string PhoneNumber { get; set; }
        [Required, MaxLength(50)]
        public string Email { get; set; }
        [Required, MaxLength(200)]
        public string Address { get; set; }
        public UserDetails(User user, string firstName, string lastName, int personCode, string phoneNumber, string email, byte[] profilePic, string address)
        {
            Id = new Guid();
            User = user;
            FirstName = firstName;
            LastName = lastName;
            PersonCode = personCode;
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;
        }
    }
}
