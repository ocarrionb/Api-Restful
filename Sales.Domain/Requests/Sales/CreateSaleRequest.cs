using Sales.Domain.Requests.Concepts;

namespace Sales.Domain.Requests.Sales
{
    public class CreateSaleRequest
    {
        public DateTime? Date { get; set; }
        public required int CustomerId { get; set; }
        public decimal Total { get; set; }
        public required CreateConceptRequest ConceptRequest { get; set; }
    }
}
