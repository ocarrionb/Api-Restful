using Sales.Domain.Entity;

namespace Sales.Repository.Queries.Customers
{
    public interface IAllCustomersQueriesRepository
    {
        ICollection<Customer> GetAllCustomers();
    }
}
