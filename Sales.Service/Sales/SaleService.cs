using AutoMapper;
using Sales.Domain.Entity;
using Sales.Domain.Requests.Sales;
using Sales.Domain.Responses.Products;
using Sales.Domain.Responses.Sales;
using Sales.Repository.Commands.Sales;
using Sales.Repository.Queries.Sales;

namespace Sales.Service.Sales
{
    public sealed class SaleService : ISaleService
    {
        private readonly ISaleCommandsRepository _commandsRepository;
        private readonly ISaleByDateRangeQueriesRepository _queriesRepository;
        private readonly IMapper _mapper;
        public SaleService(ISaleCommandsRepository commandsRepository,
            ISaleByDateRangeQueriesRepository queriesRepository,
            IMapper mapper)
        {
            _commandsRepository = commandsRepository;
            _queriesRepository = queriesRepository;
            _mapper = mapper;
        }
        public async Task<SaleResponse> CreateSale(CreateSaleRequest request)
            => _mapper.Map<SaleResponse>(await _commandsRepository.CreateSale(_mapper.Map<Sale>(request)));

        public IEnumerable<SaleResponse> GetSalesByDateRange(GetSaleRequest request)
        {
            var listSalesResponse = new List<SaleResponse>();
            _queriesRepository.GetSalesByDateRange(request).ToList()
                .ForEach(sale => listSalesResponse.Add(_mapper.Map<SaleResponse>(sale)));
            return listSalesResponse;
        }
    }
}
