﻿using AutoFixture.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeAndAttendanceSystem.Repositories.Models.Entities;

namespace TimeAndAttendanceSystem.Repositories.Tests
{
    public class UserDetailsSpecimenBuilder : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            if (request is Type type && type == typeof(UserDetails))
            {
                //return new UserDetails("testingUser", Encoding.ASCII.GetBytes("abcd"), Encoding.ASCII.GetBytes("abcd"));
            }
            return new NoSpecimen();
        }
    }
}
