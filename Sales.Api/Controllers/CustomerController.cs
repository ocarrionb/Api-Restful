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
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] CreateCustomerRequest createCustomerRequest)
        {
            bool validate = _customerService.IsUnique(createCustomerRequest.Name);
            if (!validate)
            {
                return StatusCode(400, "Customer is already used.");
            }

            if (!ModelState.IsValid || createCustomerRequest == null)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var customerResponse = await _customerService.CreateCustomer(createCustomerRequest);
                if (customerResponse == null)
                    return StatusCode(500, "Internal server error, please contact support");

                return StatusCode(StatusCodes.Status201Created, customerResponse);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                return StatusCode(500, "Internal server error, please contact support");
            }
        }

        [HttpGet("GetAllCustomers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllCustomers()
        {
            try
            {
                var customerListResponse = _customerService.GetAllCustomers();
                if (customerListResponse == null)
                {
                    return NotFound();
                }
                return Ok(customerListResponse);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                return StatusCode(500, "Internal server error, please contact support");
            }
        }

        [HttpGet("GetCustomerById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetCustomerById(int CustomerId)
        {
            try
            {
                var customerResponse = _customerService.GetCustomerById(CustomerId);
                if (customerResponse == null)
                {
                    return NotFound();
                }
                return Ok(customerResponse);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                return StatusCode(500, "Internal server error, please contact support");
            }
        }
    }
}
