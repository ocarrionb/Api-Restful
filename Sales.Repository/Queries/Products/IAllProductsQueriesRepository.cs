using Sales.Domain.Entity;

namespace Sales.Repository.Queries.Products
{
    public interface IAllProductsQueriesRepository
    {
        ICollection<Product> GetAllProducts();
    }
}
