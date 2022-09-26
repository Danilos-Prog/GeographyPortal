using MassTransit;

namespace GeographyPortal.Services.Publishers
{
    public interface IEmailSenderService
    {
        void SendEmail(string email, string title, string subject);
    }
}
