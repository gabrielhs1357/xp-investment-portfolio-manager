using InvestmentPortfolioManager.Application.DTOs.Client;
using InvestmentPortfolioManager.Application.DTOs.Investment;
using InvestmentPortfolioManager.Application.DTOs.Transaction;

namespace InvestmentPortfolioManager.Application.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<ClientDto>> GetAllAsync();
        Task<ClientDto> GetByIdAsync(Guid id);
        Task<Guid> AddAsync(CreateClientDto clientDto);
        Task UpdateBalanceAsync(Guid clientId, decimal amount);
        ClientTransactionsDto MapClientTransactionsDto(ClientDto client, IEnumerable<TransactionDto> transactions);
        ClientInvestmentsDto MapClientInvestmentsDto(ClientDto client, IEnumerable<InvestmentDto> investments);
    }
}
