using Sales.Domain.Entity;

namespace Sales.Repository.Commands.Sales
{
    public interface IUpdateSaleCommandsRepository
    {
        bool UpdateSale(Sale sale);
    }
}
