using DotNetCore.CAP;
using Dto;
using Microsoft.AspNetCore.Mvc;

namespace Customer.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private ICapPublisher _capPublisher;

        public CustomerController(ILogger<CustomerController> logger, ICapPublisher capPublisher)
        {
            _logger = logger;
            _capPublisher = capPublisher;
        }

        [HttpPost(Name = "Create")]
        public async Task<IActionResult> Create(CustomerAddDto model)
        {
            try
            {
                await _capPublisher.PublishAsync<CustomerAddDto>("new.customer.transaction", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CustomerAPI - WelcomeSendMail", model);
                return BadRequest(ex.Message);
            }
            return Ok();
        }


    }
}
