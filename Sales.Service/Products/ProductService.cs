using AutoMapper;
using Sales.Domain.Entity;
using Sales.Domain.Requests.Products;
using Sales.Domain.Responses.Products;
using Sales.Repository.Commands.Products;

namespace Sales.Service.Products
{
    public sealed class ProductService : IProductService
    {
        private readonly IProductCommandsRepository _commandsRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductCommandsRepository commandsRepository,
            IMapper mapper)
        {
            _commandsRepository = commandsRepository;
            _mapper = mapper;
        }
        public async Task<ProductResponse> CreateProduct(CreateProductRequest request)
        {
            var createProduct = _mapper.Map<Product>(request);
            var response = await _commandsRepository.CreateProduct(createProduct);
            var productResponse = _mapper.Map<ProductResponse>(response);
            return productResponse;
        }
    }
}
