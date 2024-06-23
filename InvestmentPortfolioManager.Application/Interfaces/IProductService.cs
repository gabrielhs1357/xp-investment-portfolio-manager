using InvestmentPortfolioManager.Application.DTOs.Product;
namespace InvestmentPortfolioManager.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto> GetByIdAsync(Guid id);
        Task<Guid> AddAsync(CreateProductDto productDto);
        Task UpdateAsync(ProductDto productDto);
        Task DeleteAsync(Guid id);
    }
}
