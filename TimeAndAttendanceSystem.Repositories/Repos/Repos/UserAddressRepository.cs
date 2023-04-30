using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeAndAttendanceSystem.Repositories.DBContext;
using TimeAndAttendanceSystem.Repositories.Models.Entities;
using TimeAndAttendanceSystem.Repositories.Repos.Interfaces;

namespace TimeAndAttendanceSystem.Repositories.Repos.Repos
{
    public class UserAddressRepository :IUserAddressRepository
    {
        private TatDbContext _dbContext;
        public UserAddressRepository(TatDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddUserAddress(UserAddress userAddress)
        {
            await _dbContext.UserAddresses.AddAsync(userAddress);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteUserAddress(UserAddress userAddress)
        {

            _dbContext.UserAddresses.Remove(userAddress);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserAddress>> Get()
        {
            return await _dbContext.UserAddresses.ToListAsync();
        }

        public async Task<UserAddress> Get(Guid id)
        {
            return await _dbContext.UserAddresses.FirstOrDefaultAsync(ua => ua.Id == id);
        }

        public async Task<UserAddress> GetUserAddressByUserID(Guid userId)
        {
            return await _dbContext.UserAddresses.FirstOrDefaultAsync(ua => ua.UserId == userId);
        }

        public async Task UpdateUserAddress(UserAddress userAddress)
        {
            _dbContext.Update(userAddress);
            await _dbContext.SaveChangesAsync();
        }
    }
}
