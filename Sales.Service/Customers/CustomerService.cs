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
        private readonly ICustomerCommandsRepository _customerCommands;
        private readonly ICustomerUniqueQueriesRepository _customerUniqueQueries;
        private readonly IAllCustomersQueriesRepository _allCustomersQueriesRepository;
        private readonly ICustomerByIdQueriesRepository _customerByIdQueriesRepository;
        private readonly IMapper _mapper;
        public CustomerService(ICustomerCommandsRepository customerCommands,
            ICustomerUniqueQueriesRepository customerUniqueQueries,
            IAllCustomersQueriesRepository allCustomersQueriesRepository,
            ICustomerByIdQueriesRepository customerByIdQueriesRepository,
            IMapper mapper) 
        {
            _customerCommands = customerCommands;
            _customerUniqueQueries = customerUniqueQueries;
            _allCustomersQueriesRepository = allCustomersQueriesRepository;
            _customerByIdQueriesRepository = customerByIdQueriesRepository;
            _mapper = mapper;
        }
        public async Task<CustomerResponse> CreateCustomer(CreateCustomerRequest request)
            => _mapper.Map<CustomerResponse>(await _customerCommands.CreateCustomer(_mapper.Map<Customer>(request)));
        public ICollection<CustomerResponse> GetAllCustomers()
        {
            var listCustomersResponse = new List<CustomerResponse>();            
            _allCustomersQueriesRepository.GetAllCustomers().ToList()
                .ForEach(customer => listCustomersResponse.Add(_mapper.Map<CustomerResponse>(customer)));
            return listCustomersResponse;
        }
        public CustomerResponse GetCustomerById(int CustomerId)
            => _mapper.Map<CustomerResponse>(_customerByIdQueriesRepository.GetCustomerById(CustomerId));
        public bool IsUnique(string Name)
            => _customerUniqueQueries.IsUniqueCustomer(Name);
    }
}
