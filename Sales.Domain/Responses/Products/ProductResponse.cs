using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Domain.Responses.Products
{
    public class ProductResponse
    {
        public int ProductId { get; set; }
        public required string Name { get; set; }
        public required string UnitPrice { get; set; }
        public decimal Cost { get; set; }
    }
}
