using Sales.Domain.Entity;
using Sales.Domain.Requests.Sales;

namespace Sales.Repository.Queries.Sales
{
    public interface ISaleByDateRangeQueriesRepository
    {
        IEnumerable<Sale> GetSalesByDateRange(GetSaleRequest request);
    }
}
