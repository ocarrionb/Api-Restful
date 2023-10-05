using Microsoft.EntityFrameworkCore;
using Sales.Domain;
using Sales.Domain.Entity;

namespace Sales.Repository.Queries.Customers
{
    public sealed class AllCustomersQueriesRepository: IAllCustomersQueriesRepository
    {
        private readonly ApplicationDbContext _context;
        public AllCustomersQueriesRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public ICollection<Customer> GetAllCustomers()
        {
            return _context.Customer.OrderBy(u => u.Name).ToList();
        }
    }
}
