using Sales.Domain.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sales.Domain.Requests.Concepts
{
    public class CreateConceptRequest
    {
        public decimal Quantity { get; set; }
        public int ProductId { get; set; }
        public int? SaleId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }
    }
}
