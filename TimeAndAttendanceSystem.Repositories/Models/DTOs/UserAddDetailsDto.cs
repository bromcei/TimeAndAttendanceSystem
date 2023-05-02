using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeAndAttendanceSystem.Repositories.Models.DTOs
{
    public class UserAddDetailsDto
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string? FirstName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string? LastName { get; set; }
        [Required] 
        public long PersonCode { get; set; }
        [Required]
        [StringLength(12, MinimumLength = 2)]
        public string? PhoneNumber { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string? Email { get; set; }
    }
}
