using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeAndAttendanceSystem.Services.Interfaces
{
    public interface IImageReshapeService
    {
        public Task<byte[]> ResizeImage(byte[] imageBytes);
        public Task<Image> DownloadImage(byte[] imageData);
    }
}
