using InvestmentPortfolioManager.Application.DTOs.Client;

namespace InvestmentPortfolioManager.Application.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<ClientDto>> GetAllAsync();
        Task<Guid> AddAsync(CreateClientDto clientDto);
        Task<ClientDto> GetByIdAsync(Guid id);
        Task UpdateBalanceAsync(Guid clientId, decimal amount);
    }
}
