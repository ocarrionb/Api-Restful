using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sales.Domain.Entity
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [MaxLength(50)]
        public required string Name { get; set; }
        
        [MaxLength(50)]
        public required string UnitPrice { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        public decimal Cost { get; set; }
    }
}
