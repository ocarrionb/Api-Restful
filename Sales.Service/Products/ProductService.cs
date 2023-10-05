using AutoMapper;
using Sales.Domain.Entity;
using Sales.Domain.Requests.Products;
using Sales.Domain.Responses.Products;
using Sales.Repository.Commands.Products;
using Sales.Repository.Queries.Products;

namespace Sales.Service.Products
{
    public sealed class ProductService : IProductService
    {
        private readonly IProductCommandsRepository _commandsRepository;
        private readonly IAllProductsQueriesRepository _allProductsQueriesRepository;
        private readonly IProductByIdQueriesRepository _productByIdQueriesRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductCommandsRepository commandsRepository,
            IAllProductsQueriesRepository allProductsQueriesRepository,
            IProductByIdQueriesRepository productByIdQueriesRepository,
            IMapper mapper)
        {
            _commandsRepository = commandsRepository;
            _allProductsQueriesRepository = allProductsQueriesRepository;
            _productByIdQueriesRepository = productByIdQueriesRepository;
            _mapper = mapper;
        }
        public async Task<ProductResponse> CreateProduct(CreateProductRequest request)
            => _mapper.Map<ProductResponse>(await _commandsRepository.CreateProduct(_mapper.Map<Product>(request)));

        public ICollection<ProductResponse> GetAllProducts()
        {
            var listProductsResponse = new List<ProductResponse>();
            _allProductsQueriesRepository.GetAllProducts().ToList()
                .ForEach(product => listProductsResponse.Add(_mapper.Map<ProductResponse>(product)));
            return listProductsResponse;
        }

        public ProductResponse GetProductById(int productId)
            => _mapper.Map<ProductResponse>(_productByIdQueriesRepository.GetProductById(productId));
    }
}
