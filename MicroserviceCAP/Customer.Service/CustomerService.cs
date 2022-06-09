using DotNetCore.CAP;
using Dto;
using Mapster;
using Microsoft.Extensions.Logging;

namespace Customer.Service
{
    public interface ICustomerService
    {
        Task Add(CustomerAddDto model);
    }

    public class CustomerService : ICustomerService, ICapSubscribe
    {
        private readonly ICapPublisher _capPublisher;
        private readonly ILogger<CustomerService> _logger;
        public CustomerService(ICapPublisher capPublisher, ILogger<CustomerService> logger)
        {
            _capPublisher = capPublisher;
            _logger = logger;
        }

        [CapSubscribe("new.customer.transaction")]
        public async Task Add(CustomerAddDto model)
        {
            _logger.LogInformation("Running.. new.customer.transaction", model);
            WelcomeSendMailDto welcomeSendMailData = model.Adapt<WelcomeSendMailDto>();

            await _capPublisher.PublishAsync<WelcomeSendMailDto>("welcome.send.mail.transaction", welcomeSendMailData);
        }
    }
}