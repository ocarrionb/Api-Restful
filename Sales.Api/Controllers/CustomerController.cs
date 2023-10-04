using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sales.Domain.Requests.Customers;
using Sales.Repository.Queries.Customers;
using Sales.Service.Customers;

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("CreateCustomer")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateCustomerRequest createCustomerRequest)
        {
            bool validate = _customerService.IsUnique(createCustomerRequest.Name);
            if (!validate)
            {
                return StatusCode(400, "Username is already used.");
            }

            if (!ModelState.IsValid || createCustomerRequest == null)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var res = await _customerService.CreateCustomer(createCustomerRequest);
                if (res == null)
                    return StatusCode(500, "Internal server error, please contact support");

                return StatusCode(StatusCodes.Status201Created, res);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                return StatusCode(500, "Internal server error, please contact support");
            }
        }

    }
}
