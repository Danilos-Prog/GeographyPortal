using GeographyPortal.Container.Messages;
using MassTransit;

namespace GeographyPortal.Services.Publishers.Impl
{
    public class EmailSenderService : IEmailSenderService
    {
        readonly IBus _bus;

        public EmailSenderService(IBus bus)
        {
            _bus = bus;
        }

        public async void SendEmail(string email, string title, string subject)
        {
            await _bus.Publish(new MessageToSend { EmailAdress = email, TextOfEmail = title, Subject = subject });

        }
    }
}
