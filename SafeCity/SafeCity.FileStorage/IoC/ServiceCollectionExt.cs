using Microsoft.Extensions.DependencyInjection;
using SafeCity.FileStorage.Core;
using SafeCity.FileStorage.Impl;

namespace SafeCity.FileStorage.IoC
{
    public static class ServiceCollectionExt
    {
        public static void AddFileStorage(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IImageHandler, ImageHandler>();
            serviceCollection.AddSingleton<IFileStorageService, FileStorageService>();
        }
    }
}