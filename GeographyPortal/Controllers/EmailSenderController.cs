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

        /// <summary>
        /// Отправка почты на e-mail
        /// </summary>
        /// <param name="email">E-mail получателя</param>
        /// <param name="title">Заголовок письма</param>
        /// <param name="subject">Тело письма</param>
        [HttpPost]
        public void SendEmail(string email, string title, string subject)
        {
            _emailSenderService.SendEmail(email, title, subject);   
        }

    }
}
