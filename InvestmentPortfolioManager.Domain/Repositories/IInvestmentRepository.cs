using InvestmentPortfolioManager.Domain.Entities;

namespace InvestmentPortfolioManager.Domain.Repositories
{
    public interface IInvestmentRepository
    {
        Task<Investment?> GetByClientIdAndProductIdAsync(Guid clientId, Guid productId);
        Task AddAsync(Investment investment);
        Task UpdateAsync(Investment investment);
    }
}
