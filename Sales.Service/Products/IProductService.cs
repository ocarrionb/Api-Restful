using Sales.Domain.Requests.Products;
using Sales.Domain.Responses.Products;

namespace Sales.Service.Products
{
    public interface IProductService
    {
        Task<ProductResponse> CreateProduct(CreateProductRequest request);
    }
}
