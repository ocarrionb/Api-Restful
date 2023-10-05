using Sales.Domain;

namespace Sales.Repository.Queries.Customers
{
    public sealed class CustomerUniqueQueriesRepository : ICustomerUniqueQueriesRepository
    {
        private readonly ApplicationDbContext _context;
        public CustomerUniqueQueriesRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool IsUniqueCustomer(string name)
            => _ = _context.Customer.FirstOrDefault(u => u.Name == name) == null;
    }
}
