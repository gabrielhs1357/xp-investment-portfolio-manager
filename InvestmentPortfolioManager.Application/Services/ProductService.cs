using AutoMapper;
using InvestmentPortfolioManager.Application.DTOs.Product;
using InvestmentPortfolioManager.Application.Interfaces;
using InvestmentPortfolioManager.Domain.Entities;
using InvestmentPortfolioManager.Domain.Repositories;

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

        public async Task DeleteAsync(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
            {
                throw new InvalidOperationException("Product not found"); // throw a BadRequestException
            }

            await _productRepository.DeleteAsync(product);
        }

        public async Task UpdateAsync(Guid id, UpdateProductDto productDto)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
            {
                throw new InvalidOperationException("Product not found"); // throw a BadRequestException
            }

            _mapper.Map(productDto, product);

            await _productRepository.UpdateAsync(product);
        }

        public async Task<IEnumerable<ProductDto>> GetExpiringProductsAsync()
        {
            var products = await _productRepository.GetExpiringProductsAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<bool> CodeExists(string code)
        {
            return await _productRepository.CodeExists(code);
        }
    }
}
