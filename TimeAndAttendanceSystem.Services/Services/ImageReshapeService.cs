using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeAndAttendanceSystem.Services.Interfaces;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats.Png;
using System.IO;
using System.Buffers.Text;
using SixLabors.ImageSharp.Formats;

namespace TimeAndAttendanceSystem.Services.Services
{
    public class ImageReshapeService : IImageReshapeService
    {
        public async Task<byte[]> ResizeImage(byte[] imageData)
        {
            using (Image image = Image.Load(imageData))
            {
                int width = 200;
                int height = 200;
                image.Mutate(x => x.Resize(width, height, KnownResamplers.Lanczos3));

                using (var ms = new MemoryStream())
                {
                    await image.SaveAsJpegAsync(ms);
                    return ms.ToArray();
                }
            }
        }

        public async Task<Image> DownloadImage(byte[] imageData)
        {
            Image image = Image.Load(imageData);
            var ms = new MemoryStream(); 
            await image.SaveAsJpegAsync(ms);
            return image;
        }
    }
}
