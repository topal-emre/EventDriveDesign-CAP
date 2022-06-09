using DotNetCore.CAP;
using Dto;
using Microsoft.AspNetCore.Mvc;

namespace Email.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly ILogger<EmailController> _logger;
        private ICapPublisher _capPublisher;

        public EmailController(ILogger<EmailController> logger, ICapPublisher capPublisher)
        {
            _logger = logger;
            _capPublisher = capPublisher;
        }

        [HttpPost(Name = "WelcomeSendMail")]
        public async Task<IActionResult> WelcomeSendMail(WelcomeSendMailDto data)
        {
            try
            {
                await _capPublisher.PublishAsync<WelcomeSendMailDto>("welcome.send.mail.transaction", data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "EmailAPI - WelcomeSendMail", data);
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}