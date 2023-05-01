using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeAndAttendanceSystem.Repositories.Models.Entities;

namespace TimeAndAttendanceSystem.Repositories.Models.DTOs
{
    public class UserAddressDTO
    {

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public string? HouseNumberPreffix { get; set; }
    }
}
