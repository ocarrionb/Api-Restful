using System.ComponentModel.DataAnnotations;

namespace Sales.Domain.Entity
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [MaxLength(50)]
        public required string Name { get; set; }
    }
}
