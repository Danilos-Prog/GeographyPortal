using GeographyPortal.Services;
using GeographyPortal.Services.Impl;
using GeographyPortal.Services.Publishers;
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


        [HttpPost]
        public void SendEmail(string email, string title, string subject)
        {
            
        }

    }
}
