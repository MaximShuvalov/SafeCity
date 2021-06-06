using Microsoft.Extensions.DependencyInjection;
using SafeCity.EmailSender.Services;

namespace SafeCity.EmailSender.IoC
{
    public static class EmailSenderServiceCollectionExtension
    {
        public static void AddEmailSender(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IEmailSenderSettingsService, EmailSenderSettingsService>();
            serviceCollection.AddTransient<IEmailSenderService, EmailSenderService>();
        }
    }
}