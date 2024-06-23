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
        private readonly IClientService _clientService;
        private readonly IProductService _productService;

        public TransactionService(
            ITransactionRepository transactionRepository,
            IMapper mapper,
            IClientService clientService,
            IProductService productService
        )
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
            _clientService = clientService;
            _productService = productService;
        }

        public async Task<IEnumerable<TransactionDto>> GetByClientIdAsync(Guid clientId)
        {
            var transactions = await _transactionRepository.GetByClientIdAsync(clientId);
            return _mapper.Map<IEnumerable<TransactionDto>>(transactions);
        }

        public async Task<Guid> HandleBuyTransactionAsync(Guid clientId, CreateTransactionDto transactionDto)
        {
            var client = await _clientService.GetByIdAsync(clientId);

            if (client == null)
            {
                throw new InvalidOperationException("Client not found");
            }

            var product = await _productService.GetByIdAsync(transactionDto.ProductId);

            if (product == null)
            {
                throw new InvalidOperationException("Product not found");
            }

            var totalPrice = transactionDto.Quantity * product.Price;

            var clientBalance = client.Balance - totalPrice;

            if (clientBalance < 0)
            {
                throw new InvalidOperationException("Insufficient funds");
            }

            var transaction = _mapper.Map<Transaction>(transactionDto);

            transaction.ClientId = clientId;
            transaction.TransactionType = TransactionType.Buy;

            await _transactionRepository.AddAsync(transaction);

            await _clientService.UpdateBalanceAsync(clientId, clientBalance);

            return transaction.Id;
        }

        public async Task<Guid> HandleSellTransactionAsync(Guid clientId, CreateTransactionDto transactionDto)
        {
            var transaction = _mapper.Map<Transaction>(transactionDto);

            transaction.ClientId = clientId;

            transaction.TransactionType = TransactionType.Sell;

            await _transactionRepository.AddAsync(transaction);

            return transaction.Id;
        }
    }
}
