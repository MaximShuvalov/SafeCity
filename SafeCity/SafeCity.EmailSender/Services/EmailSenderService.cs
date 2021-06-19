using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using SafeCity.EmailSender.Services;

namespace SafeCity.EmailSender
{
    public class EmailSenderService : IEmailSenderService
    {
        private readonly IEmailSenderSettingsService _settingsService;

        public EmailSenderService(IEmailSenderSettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public async Task SendAsync(string textMessage, string recipientMail, string emailTopic)
        {
            var settings = _settingsService.ReadConfiguration();
            var senderMailAddress = new MailAddress(settings.SenderData.EmailAddress, settings.SenderData.SenderName);
            var destinationMailAddress = new MailAddress(recipientMail);
            var emailMessage = new MailMessage(senderMailAddress, destinationMailAddress)
            {
                Subject = emailTopic,
                Body = textMessage
            };
            var smptClient = new SmtpClient(settings.SmptServerData.ServerAddress,
                Convert.ToInt32(settings.SmptServerData.ServerPort))
            {
                Credentials = new NetworkCredential(settings.Credentials.UserName, settings.Credentials.Password),
                EnableSsl = true
            };

            await smptClient.SendMailAsync(emailMessage);
        }
    }
}