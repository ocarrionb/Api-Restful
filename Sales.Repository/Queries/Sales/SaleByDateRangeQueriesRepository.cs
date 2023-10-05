using Sales.Domain;
using Sales.Domain.Entity;
using Sales.Domain.Requests.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Repository.Queries.Sales
{
    public class SaleByDateRangeQueriesRepository : ISaleByDateRangeQueriesRepository
    {
        private readonly ApplicationDbContext _context;
        public SaleByDateRangeQueriesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Sale> GetSalesByDateRange(GetSaleRequest request)
            => _context.Sale.Where(s => s.Date >= request.StartDate && s.Date <= request.EndDate && s.Active == true);
    }
}
