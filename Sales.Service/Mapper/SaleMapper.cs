using AutoMapper;
using Sales.Domain.Entity;
using Sales.Domain.Requests.Sales;
using Sales.Domain.Responses.Sales;

namespace Sales.Service.Mapper
{
    public sealed class SaleMapper :Profile
    {
        public SaleMapper()
        {
            CreateMap<CreateSaleRequest, Sale>();
            CreateMap<Sale, SaleResponse>();
        }
    }
}
