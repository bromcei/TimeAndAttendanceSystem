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
        private TimeAndAttendanceDbContext _dbContext;
        public UserDetailsRepository(TimeAndAttendanceDbContext dbContext)
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

        public async Task<IEnumerable<UserDetails>> Get()
        {
            return await _dbContext.UserDetails.ToListAsync();
        }

        public async Task<UserDetails> Get(Guid id)
        {
            return await _dbContext.UserDetails.FirstOrDefaultAsync(ud => ud.Id == id);
        }

        public async Task<UserDetails> GetUserDetailsByUserID(Guid userId)
        {
            return await _dbContext.UserDetails.FirstOrDefaultAsync(ud => ud.UserId == userId);
        }

        public async Task UpdateUserEmail(Guid userId, string newEmail)
        {
            UserDetails userDetails = await _dbContext.UserDetails.FirstOrDefaultAsync(ud => ud.UserId == userId);
            userDetails.Email = newEmail;
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateUserFirstName(Guid userId, string newFirstName)
        {
            UserDetails userDetails = await _dbContext.UserDetails.FirstOrDefaultAsync(ud => ud.UserId == userId);
            userDetails.FirstName = newFirstName;
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateUserLastName(Guid userId, string newLastName)
        {
            UserDetails userDetails = await _dbContext.UserDetails.FirstOrDefaultAsync(ud => ud.UserId == userId);
            userDetails.LastName = newLastName;
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateUserPersonCode(Guid userId, int newPersonCode)
        {
            UserDetails userDetails = await _dbContext.UserDetails.FirstOrDefaultAsync(ud => ud.UserId == userId);
            userDetails.PersonCode = newPersonCode;
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateUserTelephone(Guid userId, string newTelephone)
        {
            UserDetails userDetails = await _dbContext.UserDetails.FirstOrDefaultAsync(ud => ud.UserId == userId);
            userDetails.PhoneNumber = newTelephone;
            await _dbContext.SaveChangesAsync();
        }
    }
}
