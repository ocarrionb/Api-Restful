using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Sales.Api.Controllers;
using Sales.Domain.Requests.Customers;
using Sales.Domain.Requests.Products;
using Sales.Service.Customers;
using Sales.Service.Products;

namespace Test
{
    public class ProductTesting
    {
        private readonly ProductController _productController;
        private readonly IProductService _productService;

        public ProductTesting()
        {
            _productService = A.Fake<IProductService>();
            _productController = new ProductController(_productService);
        }

        [Fact]
        public async void CreateCustomer_TestOK()
        {
            //Arrange
            var request = new CreateProductRequest
            {
                Name = "Test Name",
                UnitPrice = "Test UnitPrice",
                Cost = 2
            };

            //Act
            var response = await _productController.Post(request);

            //Assert
            Assert.IsType<ObjectResult>(response);
        }

        [Fact]
        public void GetAllProducts_TestOK()
        {
            //Act
            var response = _productController.GetAllProducts();

            //Assert
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public void GetProductById_TestOK()
        {
            //Act
            var response = _productController.GetProductById(1);

            //Assert
            Assert.IsType<OkObjectResult>(response);
        }
    }
}
