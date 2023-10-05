using Sales.Domain.Responses.Concepts;

namespace Sales.Domain.Responses.Sales
{
    public class SaleResponse
    {
        public int SaleId { get; set; }
        public required DateTime Date { get; set; }
        public required int CustomerId { get; set; }
        public decimal Total { get; set; }
        public ConceptResponse Concept { get; set; }
    }
}
