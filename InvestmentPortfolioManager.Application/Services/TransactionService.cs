using AutoMapper;
using InvestmentPortfolioManager.Application.DTOs.Investment;
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
        private readonly IInvestmentService _investmentService;

        public TransactionService(
            ITransactionRepository transactionRepository,
            IMapper mapper,
            IClientService clientService,
            IProductService productService,
            IInvestmentService investmentService
        )
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
            _clientService = clientService;
            _productService = productService;
            _investmentService = investmentService;
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

            if (product.AvailableQuantity < transactionDto.Quantity)
            {
                throw new InvalidOperationException("Insufficient stock");
            }

            var totalPrice = transactionDto.Quantity * product.Price;

            var clientBalance = client.Balance - totalPrice;

            if (clientBalance < 0)
            {
                throw new InvalidOperationException("Insufficient funds");
            }

            product.AvailableQuantity -= transactionDto.Quantity;

            await _productService.UpdateAsync(product);

            var transaction = _mapper.Map<Transaction>(transactionDto);

            transaction.ClientId = clientId;
            transaction.TransactionType = TransactionType.Buy;

            await _transactionRepository.AddAsync(transaction);

            await _clientService.UpdateBalanceAsync(clientId, clientBalance);

            var investment = await _investmentService.GetByClientIdAndProductIdAsync(clientId, product.Id);

            if (investment != null)
            {
                var averagePurchasePrice = (investment.AveragePurchasePrice + product.Price) / 2; 

                investment.AveragePurchasePrice = averagePurchasePrice;
                investment.Quantity += transactionDto.Quantity;

                await _investmentService.UpdateAsync(investment);
            }
            else
            {
                var investmentDto = new CreateInvestmentDto
                {
                    ClientId = clientId,
                    ProductId = product.Id,
                    Quantity = transactionDto.Quantity,
                    AveragePurchasePrice = product.Price
                };

                await _investmentService.AddAsync(investmentDto);
            }

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
