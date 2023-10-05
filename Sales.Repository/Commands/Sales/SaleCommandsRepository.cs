using Sales.Domain;
using Sales.Domain.Entity;

namespace Sales.Repository.Commands.Sales
{
    public sealed class SaleCommandsRepository : ISaleCommandsRepository
    {
        private readonly ApplicationDbContext _context;
        public SaleCommandsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Sale> CreateProduct(Sale sale)
        {
            _context.Sale.Add(sale);
            await _context.SaveChangesAsync();
            return sale;
        }
    }
}
