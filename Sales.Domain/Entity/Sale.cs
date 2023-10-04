using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sales.Domain.Entity
{
    public class Sale
    {
        [Key]
        public int SaleId { get; set; }
        public required DateTime Date { get; set; }

        [ForeignKey("Customer")]
        public required int CustomerId { get; set; }
        
        [Column(TypeName = "decimal(18,0)")]
        public decimal Total { get; set; }

        public Customer Customer { get; set; }
    }
}
