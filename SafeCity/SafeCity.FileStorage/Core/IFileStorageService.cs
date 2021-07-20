using System.Threading.Tasks;

namespace SafeCity.FileStorage.Core
{
    public interface IFileStorageService
    {
        public Task<string> SaveAttachment(string image);
    }
}