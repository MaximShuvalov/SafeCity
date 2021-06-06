using System.Threading.Tasks;

namespace SafeCity.EmailSender
{
    public interface IEmailSenderService
    {
        Task SendAsync(string textMessage, string recipientMail, string emailTopic);
    }
}