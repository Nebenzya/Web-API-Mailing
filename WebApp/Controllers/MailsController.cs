using Microsoft.AspNetCore.Mvc;
using WebApp.Data.Interface;
using WebApp.Models.DTO;
using WebApp.Services;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailsController : ControllerBase
    {
        private readonly IEmailRepository _emailRepository;
        private readonly IEmailService _emailService;

        public MailsController(IEmailRepository emailRepository, IEmailService emailService)
        {
            _emailRepository = emailRepository;
            _emailService = emailService;
        }

        /// <summary>
        /// Отправляет сообщение по e-mail
        /// </summary>
        /// <param name="email">Объект используется для отправки сообщения</param>
        /// <returns>Возвращает результат запроса</returns>
        [HttpPost]
        public IActionResult Send(EmailDTO email)
        {
            email.FailedMessage = _emailService.SendEmail(email);
            _emailRepository.Create(email);
            _emailRepository.Save();

            return Ok();
        }

        /// <summary>
        /// Возвращает все записи об e-mail сообщениях
        /// </summary>
        /// <returns>Возвращает результат запроса</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _emailRepository.GetEmails();
            return Ok(result);
        }
    }
}
