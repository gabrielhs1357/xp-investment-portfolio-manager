using AutoMapper;
using InvestmentPortfolioManager.Application.DTOs.Transaction;
using InvestmentPortfolioManager.Application.Interfaces;
using InvestmentPortfolioManager.Domain.Entities;
using InvestmentPortfolioManager.Domain.Enums;
using InvestmentPortfolioManager.Domain.Repositories;

namespace InvestmentPortfolioManager.Application.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public TransactionService(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TransactionDto>> GetByClientIdAsync(Guid clientId)
        {
            var transactions = await _transactionRepository.GetByClientIdAsync(clientId);
            return _mapper.Map<IEnumerable<TransactionDto>>(transactions);
        }

        public async Task<Guid> CreateBuyTransactionAsync(Guid clientId, CreateTransactionDto transactionDto)
        {
            var transaction = _mapper.Map<Transaction>(transactionDto);

            transaction.ClientId = clientId;

            transaction.TransactionType = TransactionType.Buy;

            await _transactionRepository.AddAsync(transaction);

            return transaction.Id;
        }

        public async Task<Guid> CreateSellTransactionAsync(Guid clientId, CreateTransactionDto transactionDto)
        {
            var transaction = _mapper.Map<Transaction>(transactionDto);

            transaction.ClientId = clientId;

            transaction.TransactionType = TransactionType.Sell;

            await _transactionRepository.AddAsync(transaction);

            return transaction.Id;
        }
    }
}
