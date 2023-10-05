using Sales.Domain.Requests.Customers;
using Sales.Domain.Responses.Customers;

namespace Sales.Service.Customers
{
    public interface ICustomerService
    {
        Task<CustomerResponse> CreateCustomer(CreateCustomerRequest request);
        ICollection<CustomerResponse> GetAllCustomers();
        CustomerResponse GetCustomerById(int CustomerId);
        bool IsUnique(string Name);
    }
}
