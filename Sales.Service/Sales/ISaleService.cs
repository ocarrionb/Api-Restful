using Sales.Domain.Requests.Sales;
using Sales.Domain.Responses.Sales;

namespace Sales.Service.Sales
{
    public interface ISaleService
    {
        Task<SaleResponse> CreateSale(CreateSaleRequest request);
        IEnumerable<SaleResponse> GetSalesByDateRange(GetSaleRequest request);
    }
}
