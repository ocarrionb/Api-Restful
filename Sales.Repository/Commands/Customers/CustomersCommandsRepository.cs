using Sales.Domain;
using Sales.Domain.Entity;

namespace Sales.Repository.Commands.Customers
{
    public class CustomersCommandsRepository : ICustomersCommandsRepository
    {
        private readonly ApplicationDbContext _context;
        public CustomersCommandsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Customer> CreateCustomer(Customer customer)
        {
            _context.Customer.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }
    }
}
