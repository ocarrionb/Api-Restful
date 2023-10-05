using Sales.Domain.Entity;

namespace Sales.Repository.Queries.Products
{
    public interface IProductByIdQueriesRepository
    {
        Product GetProductById(int productId);
    }
}
