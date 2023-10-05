using Sales.Domain.Entity;

namespace Sales.Repository.Commands.Customers
{
    public interface ICustomerCommandsRepository
    {
        Task<Customer> CreateCustomer(Customer customer);
    }
}
