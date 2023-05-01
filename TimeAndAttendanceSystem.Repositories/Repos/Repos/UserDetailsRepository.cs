using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeAndAttendanceSystem.Repositories.DBContext;
using TimeAndAttendanceSystem.Repositories.Models.Entities;
using TimeAndAttendanceSystem.Repositories.Repositories.Interfaces;

namespace TimeAndAttendanceSystem.Repositories.Repos.Repos
{
    public class UserDetailsRepository : IUserDetailsRepository
    {
        private TatDbContext _dbContext;
        public UserDetailsRepository(TatDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddUserDetails(UserDetails userDetails)
        {
            await _dbContext.UserDetails.AddAsync(userDetails);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteUserDetails(UserDetails userDetails)
        {

            _dbContext.UserDetails.Remove(userDetails);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserDetails>?> Get()
        {
            return await _dbContext.UserDetails.ToListAsync();
        }

        public async Task<UserDetails?> Get(Guid id)
        {
            return await _dbContext.UserDetails.FirstOrDefaultAsync(ud => ud.Id == id);
        }

        public async Task<UserDetails?> GetUserDetailsByUserID(Guid userId)
        {
            return await _dbContext.UserDetails.FirstOrDefaultAsync(ud => ud.UserId == userId);
        }

        public async Task UpdateUserDetails(UserDetails userDetails)
        {
            _dbContext.Update(userDetails);
            await _dbContext.SaveChangesAsync();
        }
    }
}
