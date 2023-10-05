namespace Sales.Domain.Requests.Sales
{
    public class GetSaleRequest
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
