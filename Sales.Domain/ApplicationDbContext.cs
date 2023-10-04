using Sales.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Sales.Domain
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Concept> Concept { get; set; } = default!;
        public DbSet<Customer> Customer { get; set; } = default!;
        public DbSet<Product> Product { get; set; } = default!;
        public DbSet<Sale> Sale { get; set; } = default!;
    }
}
