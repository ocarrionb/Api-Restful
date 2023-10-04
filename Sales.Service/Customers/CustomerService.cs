using AutoMapper;
using Sales.Domain.Entity;
using Sales.Domain.Requests.Customers;
using Sales.Domain.Responses.Customers;
using Sales.Repository.Commands.Customers;
using Sales.Repository.Queries.Customers;

namespace Sales.Service.Customers
{
    public sealed class CustomerService : ICustomerService
    {
        private readonly ICustomersCommandsRepository _customerCommands;
        private readonly ICustomerUniqueQueriesRepository _customerUniqueQueries;
        private readonly IMapper _mapper;
        public CustomerService(ICustomersCommandsRepository customerCommands,
            ICustomerUniqueQueriesRepository customerUniqueQueries,
            IMapper mapper) 
        {
            _customerCommands = customerCommands;
            _customerUniqueQueries = customerUniqueQueries;
            _mapper = mapper;
        }
        public async Task<CustomerResponse> CreateCustomer(CreateCustomerRequest request)
        {
            var createCustomer = _mapper.Map<Customer>(request);
            var response = await _customerCommands.CreateCustomer(createCustomer);
            var customerResponse = _mapper.Map<CustomerResponse>(response);
            return customerResponse;

        }
        public ICollection<CustomerResponse> GetAllCustomers()
        {
            throw new NotImplementedException();
        }
        public Task<CustomerResponse> GetCustomerById(int CustomerId)
        {
            throw new NotImplementedException();
        }
        public bool IsUnique(string Name)
            => _customerUniqueQueries.IsUniqueCustomer(Name);
    }
}
