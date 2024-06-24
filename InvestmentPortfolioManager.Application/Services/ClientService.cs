using AutoMapper;
using InvestmentPortfolioManager.Application.DTOs.Client;
using InvestmentPortfolioManager.Application.DTOs.ClientTransactions;
using InvestmentPortfolioManager.Application.DTOs.Transaction;
using InvestmentPortfolioManager.Application.Interfaces;
using InvestmentPortfolioManager.Domain.Entities;
using InvestmentPortfolioManager.Domain.Repositories;

namespace InvestmentPortfolioManager.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public ClientTransactionsDto MapClientTransactionsDto(ClientDto client, IEnumerable<TransactionDto> transactions)
        {
            var clientTransactions = _mapper.Map<ClientTransactionsDto>(client);
            clientTransactions.Transactions = transactions;
            return clientTransactions;
        }

        public async Task<Guid> AddAsync(CreateClientDto clientDto)
        {
            var client = _mapper.Map<Client>(clientDto);
            await _clientRepository.AddAsync(client);
            return client.Id;
        }

        public async Task<IEnumerable<ClientDto>> GetAllAsync()
        {
            var clients = await _clientRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ClientDto>>(clients);
        }

        public async Task<ClientDto> GetByIdAsync(Guid id)
        {
            var client = await _clientRepository.GetByIdAsync(id);
            return _mapper.Map<ClientDto>(client);
        }

        public async Task UpdateBalanceAsync(Guid clientId, decimal balance)
        {
            var client = await _clientRepository.GetByIdAsync(clientId);

            client.Balance = balance;

            await _clientRepository.UpdateAsync(client);
        }
    }
}
