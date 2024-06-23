using InvestmentPortfolioManager.Application.DTOs.Client;

namespace InvestmentPortfolioManager.Application.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<ClientDto>> GetAllAsync();
        Task<ClientDto> GetByIdAsync(Guid id);
        Task<Guid> AddAsync(CreateClientDto clientDto);
        Task UpdateBalanceAsync(Guid clientId, decimal amount);
    }
}
