using Sales.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Domain.Responses.Sales
{
    public class SaleResponse
    {
        public int SaleId { get; set; }
        public required DateTime Date { get; set; }
        public required int CustomerId { get; set; }
        public decimal Total { get; set; }
        public Concept Concept { get; set; }
    }
}
