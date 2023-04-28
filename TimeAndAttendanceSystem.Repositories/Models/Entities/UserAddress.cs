using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeAndAttendanceSystem.Repositories.Models.Entities
{
    public class UserAddress
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public User? User { get; set; }
        [Required, MaxLength(50)]
        public string Country { get; set; }
        [Required, MaxLength(50)]
        public string City { get; set; }
        [Required, MaxLength(50)]
        public string Street { get; set; }
        [Required, MaxLength(100)]
        public int HouseNumber { get; set; }
        [MaxLength(2)]
        public string? HouseNumberPreffix { get; set; }
        public UserAddress(Guid userId, string country, string city, string street, int houseNumber)
        {
            UserId = userId;
            Country = country;
            City = city;
            Street = street;
            HouseNumber = houseNumber;
        }
        
    }
}
