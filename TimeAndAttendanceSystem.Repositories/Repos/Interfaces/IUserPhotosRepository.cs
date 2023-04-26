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
        public IEnumerable<UserPhoto> Get();
        public UserPhoto GetUserPhoto(Guid userId);
        public void AddNewUserPhoto(UserPhoto userPhoto);
        public void DeleteUserPhoto(Guid userId);


    }
}
