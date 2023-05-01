using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeAndAttendanceSystem.Repositories.Mappers
{
    public class AutoMapperConfig
    {
        public static IMapper Initialize()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });

            return config.CreateMapper();
        }
    }
}
