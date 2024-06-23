
using InvestmentPortfolioManager.Domain.Entities;

namespace InvestmentPortfolioManager.Domain.Repositories
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Transaction>> GetByClientIdAsync(Guid id);
        Task AddAsync(Transaction? transaction);
    }
}
