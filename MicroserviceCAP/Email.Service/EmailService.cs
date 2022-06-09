using DotNetCore.CAP;
using Dto;
using Microsoft.Extensions.Logging;

namespace Email.Service
{
    public interface IEmailService
    {
        void WelcomeSendMail(WelcomeSendMailDto model);
    }
    public class EmailService : IEmailService, ICapSubscribe
    {
        private readonly ICapPublisher _capPublisher;
        private readonly ILogger<EmailService> _logger;
        public EmailService(ICapPublisher capPublisher, ILogger<EmailService> logger)
        {
            _capPublisher = capPublisher;
            _logger = logger;
        }


        [CapSubscribe("welcome.send.mail.transaction")]
        public void WelcomeSendMail(WelcomeSendMailDto model)
        {
            _logger.LogInformation("Running... welcome.send.mail.transaction", model);
        }
    }
}