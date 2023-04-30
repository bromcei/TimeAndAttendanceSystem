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
    public class UserPhotosRepository : IUserPhotosRepository
    {
        private readonly TatDbContext _dbContext;
        public UserPhotosRepository(TatDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddUserPhoto(UserPhoto userPhoto)
        {
            await _dbContext.UserPhotos.AddAsync(userPhoto);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteUserPhoto(UserPhoto userPhoto)
        {
            _dbContext.UserPhotos.Remove(userPhoto);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserPhoto>> Get()
        {
            return await _dbContext.UserPhotos.ToListAsync();
        }

        public async Task<UserPhoto> Get(Guid id)
        {
            return await _dbContext.UserPhotos.FirstOrDefaultAsync(up => up.Id == id);
        }

        public async Task<UserPhoto> GetUserPhoto(Guid userId)
        {
            return await _dbContext.UserPhotos.FirstOrDefaultAsync(up => up.UserId == userId);
        }

        public async Task UpdateUserPhoto(UserPhoto userPhoto)
        {
            _dbContext.Update(userPhoto);
            await _dbContext.SaveChangesAsync();
        }
    }
}
