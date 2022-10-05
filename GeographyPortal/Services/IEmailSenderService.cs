using GeographyPortal.Container.Messages;

namespace GeographyPortal.Services
{
    public interface IEmailSenderService
    {
        public Task SendEmail(MessageToSend data);
    }
}
