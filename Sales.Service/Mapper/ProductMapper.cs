using AutoMapper;
using Sales.Domain.Entity;
using Sales.Domain.Requests.Products;
using Sales.Domain.Responses.Products;

namespace Sales.Service.Mapper
{
    public sealed class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<CreateProductRequest, Product>();
            CreateMap<Product, ProductResponse>();
        }
    }
}
