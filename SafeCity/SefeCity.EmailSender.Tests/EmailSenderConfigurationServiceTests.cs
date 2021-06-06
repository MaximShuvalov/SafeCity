using System;
using System.IO;
using System.Text.Json;
using NUnit.Framework;
using SafeCity.EmailSender.Model;
using SafeCity.EmailSender.Services;

namespace SefeCity.EmailSender.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void BindConfigTests()
        {
            var configService = new EmailSenderSettingsService();
            var configFilePath =
                Path.Combine(Directory.GetParent(AppContext.BaseDirectory).FullName, "appsettings.json");
            var configFileText = File.ReadAllText(configFilePath);
            EmailSenderSettings restoredConfig = JsonSerializer.Deserialize<EmailSenderSettings>(configFileText);
            var config = configService.ReadConfiguration();

            Assert.True(config.Credentials.Password.Equals(restoredConfig.Credentials.Password));
            Assert.True(config.Credentials.UserName.Equals(restoredConfig.Credentials.UserName));
            Assert.True(config.SenderData.EmailAddress.Equals(restoredConfig.SenderData.EmailAddress));
            Assert.True(config.SenderData.SenderName.Equals(restoredConfig.SenderData.SenderName));
            Assert.True(config.SmptServerData.ServerAddress.Equals(restoredConfig.SmptServerData.ServerAddress));
            Assert.True(config.SmptServerData.ServerPort.Equals(restoredConfig.SmptServerData.ServerPort));
        }
    }
}