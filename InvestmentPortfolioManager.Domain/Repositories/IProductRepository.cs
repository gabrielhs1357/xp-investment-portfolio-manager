using InvestmentPortfolioManager.Domain.Entities;

namespace InvestmentPortfolioManager.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product?>> GetAllAsync();
        Task<Product> GetByIdAsync(Guid id);
        Task AddAsync(Product? asset);
        Task UpdateAsync(Product asset);
        Task DeleteAsync(Product product);
        Task<IEnumerable<Product?>> GetExpiringProductsAsync();
        Task<bool> CodeExists(string code);
    }
}
