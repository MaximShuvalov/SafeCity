using SafeCity.EmailSender.Model;

namespace SafeCity.EmailSender.Services
{
    public interface IEmailSenderSettingsService
    {
        EmailSenderSettings ReadConfiguration();
    }
}