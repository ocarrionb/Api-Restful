using Sales.Domain.Requests.Sales;
using Sales.Domain.Responses.Sales;

namespace Sales.Service.Sales
{
    public sealed class SaleService : ISaleService
    {
        public SaleService()
        {
            
        }
        public Task<SaleResponse> CreateSale(CreateSaleRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
