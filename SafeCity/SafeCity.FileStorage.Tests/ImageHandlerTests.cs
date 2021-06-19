using System.IO;
using System.Threading.Tasks;
using NUnit.Framework;
using SafeCity.FileStorage.Impl;

namespace SafeCity.FileStorage.Tests
{
    public class ImageHandlerTests
    {
        private readonly string _pathToFiles = Path.Combine(Directory.GetCurrentDirectory(), "Files");
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task CreateImageFromBytesArrayTest()
        {
            var originalImageBytes = await File.ReadAllBytesAsync(Path.Combine(_pathToFiles, "1.jpg"));
            var imageHandler = new ImageHandler();
            var convertingImage = await imageHandler.CreateImageFromBytes(originalImageBytes);
            Assert.IsTrue(convertingImage != null);
        }
        
        [Test]
        public async Task SetDefaultResolutionTest()
        {
            var originalImageBytes = await File.ReadAllBytesAsync(Path.Combine(_pathToFiles, "1.jpg"));
            var imageHandler = new ImageHandler();
            var convertingImage = await imageHandler.CreateImageFromBytes(originalImageBytes);
            var resultImage = await imageHandler.SetDefaultSizeImage(convertingImage);
            Assert.IsTrue(resultImage.Width == 1000);
            Assert.IsTrue(resultImage.Height == 1000);
        }
    }
}