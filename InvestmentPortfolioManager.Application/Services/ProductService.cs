using AutoMapper;
using InvestmentPortfolioManager.Application.DTOs.Product;
using InvestmentPortfolioManager.Application.Interfaces;

namespace InvestmentPortfolioManager.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> GetByIdAsync(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<Guid> AddAsync(CreateProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);

            await _productRepository.AddAsync(product);

            return product.Id;
        }

        public async Task DeactivateAsync(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            product.IsActive = false;

            await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _productRepository.DeleteAsync(id);
        }


        public async Task UpdateAsync(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _productRepository.UpdateAsync(product);
        }
    }

    public interface IProductRepository
    {
        Task<IEnumerable<Product?>> GetAllAsync();
        Task<Product> GetByIdAsync(Guid id);
        Task AddAsync(Product? asset);
        Task UpdateAsync(Product asset);
        Task DeleteAsync(Guid id);
    }

    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int AvailableQuantity { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime Created { get; set; }
    }
}
