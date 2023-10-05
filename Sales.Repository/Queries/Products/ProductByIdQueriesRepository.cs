using Sales.Domain;
using Sales.Domain.Entity;

namespace Sales.Repository.Queries.Products
{
    public sealed class ProductByIdQueriesRepository : IProductByIdQueriesRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductByIdQueriesRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Product GetProductById(int productId)
            => _context.Product.FirstOrDefault(x => x.ProductId == productId);
    }
}
