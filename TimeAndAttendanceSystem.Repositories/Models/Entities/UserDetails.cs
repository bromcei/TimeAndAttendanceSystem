using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public User? User { get; set; }
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        public long PersonCode { get; set; }
        [Required, MaxLength(12)]
        public string PhoneNumber { get; set; }
        [Required, MaxLength(50)]
        public string Email { get; set; }
        public UserDetails(Guid userId, string firstName, string lastName, long personCode, string phoneNumber, string email)
        {
            Id = new Guid();
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            PersonCode = personCode;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}
