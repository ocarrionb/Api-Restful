using Sales.Domain;
using Sales.Domain.Entity;

namespace Sales.Repository.Commands.Products
{
    public sealed class ProductCommandsRepository : IProductCommandsRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductCommandsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Product> CreateProduct(Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
