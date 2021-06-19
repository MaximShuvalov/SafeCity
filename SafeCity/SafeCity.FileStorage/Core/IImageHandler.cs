using System.Drawing;
using System.Threading.Tasks;

namespace SafeCity.FileStorage.Core
{
    public interface IImageHandler
    {
        public Task<Image> CreateImageFromBytes(byte[] imageBytes);

        public Task<Image> SetDefaultSizeImage(Image convertingImage);
    }
}