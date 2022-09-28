using GeographyPortal.Container.Messages;
using MassTransit;

namespace GeographyPortal.Services.Publishers.Impl
{
    public class EmailSenderService : IEmailSenderService
    {
        readonly ISendEndpointProvider _sendEndpointProvider;

        public EmailSenderService(ISendEndpointProvider sendEndpointProvider)
        {
            _sendEndpointProvider = sendEndpointProvider;
        }

        public async void SendEmail(string email, string title, string subject)
        {
            var endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:order"));
            
            await endpoint.Send(new MessageToSend { EmailAdress = email, TextOfEmail = title, Subject = subject });
        }
    }
}
