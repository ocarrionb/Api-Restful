using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Sales.Api.Controllers;
using Sales.Domain.Requests.Customers;
using Sales.Domain.Requests.Sales;
using Sales.Service.Concepts;
using Sales.Service.Customers;
using Sales.Service.Products;
using Sales.Service.Sales;
using Sales.Domain.Requests.Concepts;

namespace Test
{
    public class SaleTesting
    {
        private readonly SaleController _saleController;
        private readonly ISaleService _saleService;
        private readonly IConceptService _conceptService;
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;

        public SaleTesting()
        {
            _saleService = A.Fake<ISaleService>();
            _conceptService = A.Fake<IConceptService>();
            _customerService = A.Fake<ICustomerService>();
            _productService = A.Fake<IProductService>();
            _saleController = new SaleController(_saleService,
                _conceptService, 
                _customerService, 
                _productService);
        }

        [Fact] 
        public async void CreateSale_TestOK()
        {
            //Arrange
            var request = new CreateSaleRequest
            {
                Date = new DateTime(),
                CustomerId = 1,
                Total = 6,
                ConceptRequest = new CreateConceptRequest
                {
                    Quantity = 1,
                    ProductId = 1,
                    SaleId = 1,
                    UnitPrice = 1,
                    Amount = 1,
                }
            };

            //Act
            var response = await _saleController.Post(request);

            //Assert
            Assert.IsType<ObjectResult>(response);
        }

        [Fact]
        public void GetSalesByDateRange_TestOK()
        {
            var request = new GetSaleRequest
            {
                StartDate = new DateTime(),
                EndDate = new DateTime()
            };
            //Act
            var response = _saleController.GetSalesByDateRange(request);

            //Assert
            Assert.IsType<OkObjectResult>(response);
        }
    }
}
