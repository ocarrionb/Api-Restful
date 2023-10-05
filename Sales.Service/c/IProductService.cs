using Sales.Domain.Entity;
using Sales.Domain.Requests.Products;
using Sales.Domain.Responses.Customers;
using Sales.Domain.Responses.Products;

namespace Sales.Service.Products
{
    public interface IProductService
    {
        Task<ProductResponse> CreateProduct(CreateProductRequest request);
        ICollection<ProductResponse> GetAllProducts();
        ProductResponse GetProductById(int productId);
    }
}
