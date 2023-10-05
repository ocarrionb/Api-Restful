using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sales.Domain.Requests.Products
{
    public class CreateProductRequest
    {
        [MaxLength(50)]
        public required string Name { get; set; }

        [MaxLength(50)]
        public required string UnitPrice { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        public decimal Cost { get; set; }
    }
}
