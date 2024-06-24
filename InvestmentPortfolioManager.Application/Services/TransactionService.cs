using AutoMapper;
using InvestmentPortfolioManager.Application.DTOs.Client;
using InvestmentPortfolioManager.Application.DTOs.Investment;
using InvestmentPortfolioManager.Application.DTOs.Product;
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
                throw new InvalidOperationException("Client not found"); // throw a BadRequestException
            }

            var product = await _productService.GetByIdAsync(transactionDto.ProductId);

            if (product == null)
            {
                throw new InvalidOperationException("Product not found"); // throw a BadRequestException
            }

            if (product.AvailableQuantity < transactionDto.Quantity)
            {
                throw new InvalidOperationException("Insufficient stock"); // throw a BadRequestException
            }

            if (product.Price * transactionDto.Quantity > client.Balance)
            {
                throw new InvalidOperationException("Insufficient funds"); // throw a BadRequestException
            }

            if (product.ExpirationDate < DateTime.Now)
            {
                throw new InvalidOperationException("Product expired"); // throw a BadRequestException
            }

            // Update product

            var updateProductDto = new UpdateProductDto
            {
                Name = product.Name,
                Description = product.Description,
                AvailableQuantity = product.AvailableQuantity - transactionDto.Quantity,
                Price = product.Price,
                ExpirationDate = product.ExpirationDate,
            };

            await _productService.UpdateAsync(product.Id, updateProductDto);

            // Update client

            var updateClientDto = new UpdateClientDto
            {
                Balance = client.Balance - transactionDto.Quantity * product.Price,
            };

            await _clientService.UpdateClientAsync(client.Id, updateClientDto);

            // Create transaction

            var transaction = _mapper.Map<Transaction>(transactionDto);

            transaction.ClientId = clientId;
            transaction.ProductId = product.Id;
            transaction.Quantity = transactionDto.Quantity;
            transaction.UnitPrice = product.Price;
            transaction.TotalPrice = product.Price * transactionDto.Quantity;
            transaction.TransactionType = TransactionType.Buy;

            await _transactionRepository.AddAsync(transaction);

            // Create or update investment

            var investment = await _investmentService.GetByClientIdAndProductIdAsync(clientId, product.Id);

            if (investment == null)
            {
                var createInvestmentDto = new CreateInvestmentDto
                {
                    ClientId = clientId,
                    ProductId = product.Id,
                    Quantity = transactionDto.Quantity
                };

                await _investmentService.AddAsync(createInvestmentDto);
            }
            else
            {
                var updateInvestmentDto = new UpdateInvestmentDto
                {
                    Quantity = investment.Quantity + transactionDto.Quantity,
                };

                await _investmentService.UpdateAsync(investment.InvestmentId, updateInvestmentDto);
            }

            return transaction.Id;
        }

        public async Task<Guid> HandleSellTransactionAsync(Guid clientId, CreateTransactionDto transactionDto)
        {
            var client = await _clientService.GetByIdAsync(clientId);

            if (client == null)
            {
                throw new InvalidOperationException("Client not found"); // throw a BadRequestException
            }

            var product = await _productService.GetByIdAsync(transactionDto.ProductId);

            if (product == null)
            {
                throw new InvalidOperationException("Product not found"); // throw a BadRequestException
            }

            var investment = await _investmentService.GetByClientIdAndProductIdAsync(clientId, transactionDto.ProductId);

            if (investment == null || investment.Quantity < transactionDto.Quantity)
            {
                throw new InvalidOperationException("Insufficient investment quantity"); // throw a BadRequestException
            }

            // Update product

            var updateProductDto = new UpdateProductDto
            {
                Name = product.Name,
                Description = product.Description,
                AvailableQuantity = product.AvailableQuantity + transactionDto.Quantity,
                Price = product.Price,
                ExpirationDate = product.ExpirationDate,
            };

            await _productService.UpdateAsync(product.Id, updateProductDto);

            // Update client

            var updateClientDto = new UpdateClientDto
            {
                Balance = client.Balance + transactionDto.Quantity * product.Price,
            };

            await _clientService.UpdateClientAsync(client.Id, updateClientDto);

            // Create transaction

            var transaction = _mapper.Map<Transaction>(transactionDto);

            transaction.ClientId = clientId;
            transaction.ProductId = product.Id;
            transaction.Quantity = transactionDto.Quantity;
            transaction.UnitPrice = product.Price;
            transaction.TotalPrice = product.Price * transactionDto.Quantity;
            transaction.TransactionType = TransactionType.Sell;

            await _transactionRepository.AddAsync(transaction);

            // Update investment

            var updateInvestmentDto = new UpdateInvestmentDto
            {
                Quantity = investment.Quantity - transactionDto.Quantity,
            };

            await _investmentService.UpdateAsync(investment.InvestmentId, updateInvestmentDto);

            return transaction.Id;
        }
    }
}
