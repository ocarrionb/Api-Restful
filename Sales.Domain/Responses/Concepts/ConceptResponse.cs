using Sales.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Domain.Responses.Concepts
{
    public class ConceptResponse
    {
        public int ConceptId { get; set; }
        public decimal Quantity { get; set; }
        public int ProductId { get; set; }
        public int SaleId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }
    }
}
