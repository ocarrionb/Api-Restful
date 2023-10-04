using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sales.Domain.Entity
{
    public class Concept
    {
        [Key]
        public int ConceptId { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        public decimal Quantity { get; set; }
        
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [ForeignKey("Sale")]
        public int SaleId { get; set; }
        public Sale Sale { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        public decimal UnitPrice { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        public decimal Amount { get; set; }
    }
}
