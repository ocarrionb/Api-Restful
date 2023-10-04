using Sales.Domain.Entity;

namespace Sales.Repository.Commands.Customers
{
    public interface ICustomersCommandsRepository
    {
        Task<Customer> CreateCustomer(Customer customer);
    }
}
