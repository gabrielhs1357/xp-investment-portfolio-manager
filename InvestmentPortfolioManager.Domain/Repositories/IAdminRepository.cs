using InvestmentPortfolioManager.Domain.Entities;

namespace InvestmentPortfolioManager.Domain.Repositories
{
    public interface IAdminRepository
    {
        Task<IEnumerable<Admin>> GetAllAsync();
        Task<Admin?> GetByIdAsync(Guid id);
        Task AddAsync(Admin admin);
        Task<bool> EmailExists(string email);
    }
}
