using AutoMapper;
using Sales.Domain.Entity;
using Sales.Domain.Requests.Customers;
using Sales.Domain.Responses.Customers;

namespace Sales.Service.Mapper
{
    public sealed class CustomerMapper : Profile
    {
        public CustomerMapper() {
            CreateMap<CreateCustomerRequest, Customer>();
            CreateMap<Customer, CustomerResponse>();
        }
    }
}
