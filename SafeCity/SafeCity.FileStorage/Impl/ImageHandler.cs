using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using SafeCity.FileStorage.Core;

namespace SafeCity.FileStorage.Impl
{
    public class ImageHandler : IImageHandler
    {
        public Task<Image> CreateImageFromBytes(string imageBytes) =>
            Task.Run(() =>
            {
                byte[] bytes = Convert.FromBase64String(imageBytes);
                using MemoryStream ms = new MemoryStream(bytes);
                var image = Image.FromStream(ms);
                return image;
            });

        public Task<Image> SetDefaultSizeImage(Image convertingImage) => Task.Run(() =>
        {
            if (convertingImage == null) throw new ArgumentException("Image = Null");

            return (Image)(new Bitmap(convertingImage, new Size(1000, 1000)));
        });
    }
}