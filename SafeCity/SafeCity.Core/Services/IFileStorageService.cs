namespace SafeCity.Core.Services
{
    public interface IFileStorageService
    {
        public string SaveAttachment(byte[] attachment);
    }
}