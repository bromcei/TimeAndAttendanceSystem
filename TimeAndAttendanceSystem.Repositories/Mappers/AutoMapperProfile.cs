using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeAndAttendanceSystem.Repositories.Models.DTOs;
using TimeAndAttendanceSystem.Repositories.Models.Entities;

namespace TimeAndAttendanceSystem.Repositories.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<UserAddress, UserAddressDTO>().ReverseMap();
            CreateMap<UserDetails, UserDetailsDTO>().ReverseMap();
            CreateMap<UserPhoto, UserPhotoDTO>().ReverseMap();
        }
    }
}
