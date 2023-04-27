﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeAndAttendanceSystem.Repositories.Models.Entities;

namespace TimeAndAttendanceSystem.Repositories.Repos.Interfaces
{
    public interface IUserAddressRepository
    {
        public Task<IEnumerable<UserAddress>> Get();
        public Task<UserAddress> Get(Guid id);
        public Task<UserAddress> GetUserAddressByUserID(Guid userId);
        public Task AddUserAddress(UserAddress userAddress);
        public Task DeleteUserAddress(Guid userId);
        public Task UpdateUserAddressCountry(Guid userId, string newCountry);
        public Task UpdateUserAddressCity(Guid userId, string newCity);
        public Task UpdateUserAddressStreet(Guid userId, string newStreet);
        public Task UpdateUserAddressHouseNumber(Guid userId, string newHouseNumber);
    }
}
