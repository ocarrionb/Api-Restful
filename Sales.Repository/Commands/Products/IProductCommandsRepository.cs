using Sales.Domain.Entity;

namespace Sales.Repository.Commands.Products
{
    public interface IProductCommandsRepository
    {
        Task<Product> CreateProduct(Product product);
    }
}
