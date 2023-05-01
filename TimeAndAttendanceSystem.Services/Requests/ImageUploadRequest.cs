using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeAndAttendanceSystem.Services.AtributeClasses;

namespace TimeAndAttendanceSystem.Services.Requests
{
    public class ImageUploadRequest
    {
        [AllowedExtensionsAtribute(new string[] { ".jpg", })]
        public IFormFile Image { get; set; }
    }
}
