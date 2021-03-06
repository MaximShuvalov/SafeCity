using System;
using System.IO;
using System.Threading.Tasks;
using SafeCity.FileStorage.Core;

namespace SafeCity.FileStorage.Impl
{
    public class FileStorageService : IFileStorageService
    {
        private readonly string _attachmentPath = Path.Combine(Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile), "attachments");
        private readonly IImageHandler _imageHandler;

        public FileStorageService(IImageHandler imageHandler)
        {
            _imageHandler = imageHandler;
        }

        public async Task<string> SaveAttachment(string image)
        {
            var createdImage = await _imageHandler.CreateImageFromBytes(image);

            if (image == null)
                return null;
            
            createdImage = await _imageHandler.SetDefaultSizeImage(createdImage);
            var savingPath = Path.Combine(_attachmentPath, Guid.NewGuid().ToString());

            if(!Directory.Exists(savingPath))
                Directory.CreateDirectory(savingPath);

            var imageFile = Path.Combine(savingPath, Guid.NewGuid() + ".jpg");
            
            createdImage.Save(Path.Combine(savingPath, imageFile));

            return imageFile;
        }
    }
}