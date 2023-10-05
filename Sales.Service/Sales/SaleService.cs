using AutoMapper;
using Sales.Domain.Entity;
using Sales.Domain.Requests.Sales;
using Sales.Domain.Responses.Sales;
using Sales.Repository.Commands.Sales;

namespace Sales.Service.Sales
{
    public sealed class SaleService : ISaleService
    {
        private readonly ISaleCommandsRepository _commandsRepository;
        private readonly IMapper _mapper;
        public SaleService(ISaleCommandsRepository commandsRepository,
            IMapper mapper)
        {
            _commandsRepository = commandsRepository;
            _mapper = mapper;
        }
        public async Task<SaleResponse> CreateSale(CreateSaleRequest request)
            => _mapper.Map<SaleResponse>(await _commandsRepository.CreateSale(_mapper.Map<Sale>(request)));
    }
}
