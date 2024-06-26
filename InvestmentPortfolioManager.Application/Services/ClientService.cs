﻿using AutoMapper;
using InvestmentPortfolioManager.Application.DTOs.Client;
using InvestmentPortfolioManager.Application.DTOs.Investment;
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

        public ClientInvestmentsDto MapClientInvestmentsDto(ClientDto client, IEnumerable<InvestmentDto> investments)
        {
            var clientInvestments = _mapper.Map<ClientInvestmentsDto>(client);
            clientInvestments.Investments = investments;
            return clientInvestments;
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

        public async Task<bool> EmailExists(string email)
        {
            return await _clientRepository.EmailExists(email);
        }

        public async Task UpdateClientAsync(Guid id, UpdateClientDto clientDto)
        {
            var client = await _clientRepository.GetByIdAsync(id);

            if (client == null)
            {
                throw new InvalidOperationException("Client not found"); // throw a BadRequestException
            }

            _mapper.Map(clientDto, client);

            await _clientRepository.UpdateAsync(client);
        }
    }
}
