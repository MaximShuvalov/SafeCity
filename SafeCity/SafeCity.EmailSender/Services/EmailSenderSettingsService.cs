using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using SafeCity.EmailSender.Model;

namespace SafeCity.EmailSender.Services
{
    public class EmailSenderSettingsService : IEmailSenderSettingsService
    {
        public EmailSenderSettings ReadConfiguration()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettingsEmailSender.json", false).Build();
            var settings = new EmailSenderSettings();
            config.Bind(settings);
            return settings;
        }
    }
}