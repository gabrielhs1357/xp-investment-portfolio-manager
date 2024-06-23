using InvestmentPortfolioManager.Domain.Entities;

namespace InvestmentPortfolioManager.Domain.Repositories
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAllAsync();
        Task AddAsync(Client client);
        Task<Client> GetByIdAsync(Guid id);
        Task UpdateAsync(Client client);
    }
}
