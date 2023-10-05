namespace Sales.Domain.Requests.Sales
{
    public class UpdateSaleRequest
    {
        public int SaleId { get; set; }

        public bool Active { get; set; }
    }
}
