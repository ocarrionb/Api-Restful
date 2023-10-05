using Sales.Domain;
using Sales.Domain.Entity;

namespace Sales.Repository.Queries.Products
{
    public sealed class AllProductsQueriesRepository : IAllProductsQueriesRepository
    {
        private readonly ApplicationDbContext _context;
        public AllProductsQueriesRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public ICollection<Product> GetAllProducts()
            => _context.Product.OrderBy(p => p.Name).ToList();
    }
}
