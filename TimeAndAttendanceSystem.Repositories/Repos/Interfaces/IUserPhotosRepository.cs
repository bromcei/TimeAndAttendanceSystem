using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeAndAttendanceSystem.Repositories.Models.Entities;

namespace TimeAndAttendanceSystem.Repositories.Repos.Interfaces
{
    public interface IUserPhotosRepository
    {
        public Task<IEnumerable<UserPhoto>> Get();
        public Task<UserPhoto> Get(Guid id);
        public Task<UserPhoto> GetUserPhoto(Guid userId);
        public Task UpdateUserPhoto(UserPhoto userPhoto);
        public Task DeleteUserPhoto(UserPhoto userPhoto);
    }
}
