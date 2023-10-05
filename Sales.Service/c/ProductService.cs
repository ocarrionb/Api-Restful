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
        {
            var createProduct = _mapper.Map<Product>(request);
            var response = await _commandsRepository.CreateProduct(createProduct);
            var productResponse = _mapper.Map<ProductResponse>(response);
            return productResponse;
        }

        public ICollection<ProductResponse> GetAllProducts()
        {
            var listProducts = _allProductsQueriesRepository.GetAllProducts();
            var listProductsResponse = new List<ProductResponse>();

            foreach (var item in listProducts)
            {
                listProductsResponse.Add(_mapper.Map<ProductResponse>(item));
            }
            return listProductsResponse;
        }

        public ProductResponse GetProductById(int productId)
        {
            var response = _productByIdQueriesRepository.GetProductById(productId);
            var productResponse = _mapper.Map<ProductResponse>(response);
            return productResponse;
        }
    }
}
