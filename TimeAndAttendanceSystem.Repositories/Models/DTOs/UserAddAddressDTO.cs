using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeAndAttendanceSystem.Repositories.Models.DTOs
{
    public class UserAddAddressDTO
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string? Country { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string? City { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string? Street { get; set; }
        [Required]
        public int? HouseNumber { get; set; }
        [StringLength(2, MinimumLength = 2)]
        public string? HouseNumberPreffix { get; set; }
    }
}
