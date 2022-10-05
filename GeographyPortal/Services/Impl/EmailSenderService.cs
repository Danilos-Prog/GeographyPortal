using GeographyPortal.Container.Messages;
using MassTransit;
using System.Threading.Channels;

namespace GeographyPortal.Services.Impl
{
    public class EmailSenderService : IEmailSenderService
    {
        readonly ISendEndpointProvider _sendEndpointProvider;

        public EmailSenderService(ISendEndpointProvider sendEndpointProvider)
        {
            _sendEndpointProvider = sendEndpointProvider;
        }

        public async Task SendEmail(MessageToSend data)
        {

            var endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:messages"));

            await endpoint.Send(data);
        }
    }
}
