﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeAndAttendanceSystem.Repositories.DBContext;
using TimeAndAttendanceSystem.Repositories.Models.Entities;
using TimeAndAttendanceSystem.Repositories.Repositories.Interfaces;

namespace TimeAndAttendanceSystem.Repositories.Repositories.Repos
{
    public class UserRepository : IUserRepository
    {
        private readonly TatDbContext _dbContext;
        public UserRepository(TatDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateUser(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteUser(User user)
        {
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> Get()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> Get(Guid id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> Get(string userName)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == userName);
        }

        public async Task UpdateUser(User user)
        {
            _dbContext.Update(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
