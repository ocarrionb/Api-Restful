using FakeItEasy;
using Sales.Api.Controllers;
using Sales.Domain.Requests.Customers;
using Sales.Service.Customers;
using Microsoft.AspNetCore.Mvc;

namespace Test
{
    public class CustomerTesting
    {
        private readonly CustomerController _customerController;
        private readonly ICustomerService _customerService;

        public CustomerTesting()
        {
            _customerService = A.Fake<ICustomerService>();
            _customerController = new CustomerController(_customerService);
        }

        [Fact]
        public async void CreateCustomer_TestOK()
        {
            //Arrange
            var request = new CreateCustomerRequest
            {
                Name = "Test Name",
            };

            //Act
            var response = await _customerController.Post(request);

            //Assert
            Assert.IsType<ObjectResult>(response);
        }

        [Fact]
        public void GetAllCustomers_TestOK()
        {
            //Act
            var response = _customerController.GetAllCustomers();

            //Assert
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public void GetCustomerById_TestOK()
        {
            //Act
            var response = _customerController.GetCustomerById(1);

            //Assert
            Assert.IsType<OkObjectResult>(response);
        }
    }
}
