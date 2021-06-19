using System;
using System.Drawing;
using System.Threading.Tasks;
using SafeCity.FileStorage.Core;

namespace SafeCity.FileStorage.Impl
{
    public class ImageHandler : IImageHandler
    {
        public Task<Image> CreateImageFromBytes(byte[] imageBytes) =>
            Task.Run(() => (Image) ((new ImageConverter()).ConvertFrom(imageBytes)));

        public Task<Image> SetDefaultSizeImage(Image convertingImage) => Task.Run(() =>
        {
            if (convertingImage == null) throw new ArgumentException("Image = Null");

            return (Image)(new Bitmap(convertingImage, new Size(1000, 1000)));
        });
    }
}