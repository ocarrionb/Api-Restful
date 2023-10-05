
using Microsoft.AspNetCore.Mvc;
using Sales.Domain.Requests.Customers;
using Sales.Domain.Requests.Products;
using Sales.Domain.Requests.Sales;
using Sales.Service.Concepts;
using Sales.Service.Customers;
using Sales.Service.Products;
using Sales.Service.Sales;

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;
        private readonly IConceptService _conceptService;
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;
        public SaleController(ISaleService saleService, 
            IConceptService conceptService,
            ICustomerService customerService,
            IProductService productService)
        {
            _conceptService = conceptService;
            _saleService = saleService;
            _customerService = customerService;
            _productService = productService;
        }

        [HttpPost("CreateSale")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] CreateSaleRequest createSaleRequest)
        {
            if (!ModelState.IsValid || createSaleRequest == null)
            {
                return BadRequest(ModelState);
            }
            var validateCustomer = _customerService.GetCustomerById(createSaleRequest.CustomerId);
            if (validateCustomer == null)
            {
                return StatusCode(400, "Customer does not exist.");
            }
            var validateProduct = _productService.GetProductById(createSaleRequest.ConceptRequest.ProductId);
            if (validateProduct == null)
            {
                return StatusCode(400, "Product does not exist.");
            }
            try
            {
                var saleResponse = await _saleService.CreateSale(createSaleRequest);
                
                if (saleResponse == null)
                    return StatusCode(500, "Internal server error, please contact support");
                
                createSaleRequest.ConceptRequest.SaleId = saleResponse.SaleId;
                var conceptResponse = await _conceptService.CreateConcet(createSaleRequest.ConceptRequest);
                
                if (conceptResponse == null)
                    return StatusCode(500, "Internal server error, please contact support");
                
                saleResponse.Concept = conceptResponse;
                
                return StatusCode(StatusCodes.Status201Created, saleResponse);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                return StatusCode(500, "Internal server error, please contact support");
            }
        }

        [HttpGet("GetSalesByDateRange")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetSalesByDateRange([FromQuery] GetSaleRequest request)
        {
            try
            {
                var salesResponse = _saleService.GetSalesByDateRange(request);
                if (salesResponse == null)
                {
                    return NotFound();
                }
                return Ok(salesResponse);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                return StatusCode(500, "Internal server error, please contact support");
            }
        }
    }
}
