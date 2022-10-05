using GeographyPortal.Container.Messages;
using GeographyPortal.Services;
using GeographyPortal.Services.Impl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeographyPortal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailSenderController : Controller
    {
        private readonly IEmailSenderService _emailSenderService;

        public EmailSenderController(IEmailSenderService emailSenderService)
        {
            _emailSenderService = emailSenderService;
        }

       /// <summary>
       /// Sendig email
       /// </summary>
       /// <param name="data"></param>
        [HttpPost]
        public void SendEmail(MessageToSend data)
        {
            _emailSenderService.SendEmail(data);   
        }

    }
}
