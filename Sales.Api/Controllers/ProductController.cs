using Microsoft.AspNetCore.Mvc;
using Sales.Domain.Requests.Products;
using Sales.Service.Products;

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;                        
        }

        [HttpPost("CreateProduct")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] CreateProductRequest createProductRequest)
        {
            if (!ModelState.IsValid || createProductRequest == null)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var productResponse = await _productService.CreateProduct(createProductRequest);
                if (productResponse == null)
                    return StatusCode(500, "Internal server error, please contact support");

                return StatusCode(StatusCodes.Status201Created, productResponse);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                return StatusCode(500, "Internal server error, please contact support");
            }
        }

        [HttpGet("GetAllProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllProducts()
        {
            try
            {
                var productsListResponse = _productService.GetAllProducts();
                if (productsListResponse == null)
                {
                    return NotFound();
                }
                return Ok(productsListResponse);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                return StatusCode(500, "Internal server error, please contact support");
            }
        }

        [HttpGet("GetProductById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetProductById(int ProductId)
        {
            try
            {
                var productResponse = _productService.GetProductById(ProductId);
                if (productResponse == null)
                {
                    return NotFound();
                }
                return Ok(productResponse);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                return StatusCode(500, "Internal server error, please contact support");
            }
        }
    }
}
