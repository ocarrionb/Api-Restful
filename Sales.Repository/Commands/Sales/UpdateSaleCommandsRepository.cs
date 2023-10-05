using Microsoft.EntityFrameworkCore;
using Sales.Domain;
using Sales.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Repository.Commands.Sales
{
    public class UpdateSaleCommandsRepository : IUpdateSaleCommandsRepository
    {
        private readonly ApplicationDbContext _context;

        public UpdateSaleCommandsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool UpdateSale(Sale sale)
        {
            bool result = true;
            try
            {
                _context.Sale.Where(s => s.SaleId == sale.SaleId)
                    .ExecuteUpdate(u =>
                    u.SetProperty(x => x.Active, sale.Active)
                    );
            }
            catch (Exception ex)
            {
                result = false;                
            }
            return result;
        }
    }
}
