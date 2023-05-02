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
            if (_dbContext.UserPhotos != null)
            {
                await _dbContext.UserPhotos.AddAsync(userPhoto);
                await _dbContext.SaveChangesAsync();
            }                
        }

        public async Task DeleteUserPhoto(UserPhoto userPhoto)
        {
            if (_dbContext.UserPhotos != null)
            {
                _dbContext.UserPhotos.Remove(userPhoto);
                await _dbContext.SaveChangesAsync();
            }          
        }

        public async Task<IEnumerable<UserPhoto>?> Get()
        {
            if (_dbContext.UserPhotos != null)
            {
                return await _dbContext.UserPhotos.ToListAsync();
            }
            return null;
        }

        public async Task<UserPhoto?> Get(Guid id)
        {
            if (_dbContext.UserPhotos != null)
            {
                return await _dbContext.UserPhotos.FirstOrDefaultAsync(up => up.Id == id);
            }
            return null;
        }

        public async Task<UserPhoto?> GetUserPhoto(Guid userId)
        {
            if(_dbContext.UserPhotos != null)
            {
                return await _dbContext.UserPhotos.FirstOrDefaultAsync(up => up.UserId == userId);
            }
            return null;
        }

        public async Task UpdateUserPhoto(UserPhoto userPhoto)
        {
            _dbContext.Update(userPhoto);
            await _dbContext.SaveChangesAsync();
        }
    }
}
