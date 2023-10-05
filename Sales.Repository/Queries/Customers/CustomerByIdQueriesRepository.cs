using Sales.Domain;
using Sales.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Repository.Queries.Customers
{
    public class CustomerByIdQueriesRepository : ICustomerByIdQueriesRepository
    {
        private readonly ApplicationDbContext _context;
        public CustomerByIdQueriesRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Customer GetCustomerById(int customerId)
            => _context.Customer.FirstOrDefault(x => x.CustomerId == customerId);
    }
}
