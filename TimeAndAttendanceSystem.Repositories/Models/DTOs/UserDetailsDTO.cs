﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeAndAttendanceSystem.Repositories.Models.Entities;

namespace TimeAndAttendanceSystem.Repositories.Models.DTOs
{
    public class UserDetailsDTO
    {

        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public long? PersonCode { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }       

    }
}
