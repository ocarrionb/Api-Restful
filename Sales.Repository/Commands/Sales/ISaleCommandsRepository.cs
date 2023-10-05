using Sales.Domain.Entity;

namespace Sales.Repository.Commands.Sales
{
    public interface ISaleCommandsRepository
    {
        Task<Sale> CreateSale(Sale sale);
    }
}
