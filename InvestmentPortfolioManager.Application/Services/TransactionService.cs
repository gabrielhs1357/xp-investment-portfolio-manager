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
            var client = await GetClientOrThrow(clientId);

            var product = await GetProductOrThrow(transactionDto.ProductId);

            ValidateBuyTransaction(client, product, transactionDto);

            await UpdateProductStockAsync(product, -transactionDto.Quantity);

            await UpdateClientBalanceAsync(client, -product.Price * transactionDto.Quantity);

            var transactionId = await CreateTransactionAsync(clientId, product, transactionDto, TransactionType.Buy);

            await CreateOrUpdateInvestmentAsync(clientId, product.Id, transactionDto.Quantity);

            return transactionId;
        }

        public async Task<Guid> HandleSellTransactionAsync(Guid clientId, CreateTransactionDto transactionDto)
        {
            var client = await GetClientOrThrow(clientId);

            var product = await GetProductOrThrow(transactionDto.ProductId);

            var investment = await GetInvestmentOrThrow(clientId, product.Id, transactionDto.Quantity);

            await UpdateProductStockAsync(product, transactionDto.Quantity);

            await UpdateClientBalanceAsync(client, product.Price * transactionDto.Quantity);

            var transactionId = await CreateTransactionAsync(clientId, product, transactionDto, TransactionType.Sell);

            await UpdateInvestmentAsync(investment, -transactionDto.Quantity);

            return transactionId;
        }

        private async Task<ClientDto> GetClientOrThrow(Guid clientId)
        {
            var client = await _clientService.GetByIdAsync(clientId);
            if (client == null)
            {
                throw new InvalidOperationException("Client not found");
            }
            return client;
        }

        private async Task<ProductDto> GetProductOrThrow(Guid productId)
        {
            var product = await _productService.GetByIdAsync(productId);
            if (product == null)
            {
                throw new InvalidOperationException("Product not found");
            }
            return product;
        }

        private async Task<InvestmentDto> GetInvestmentOrThrow(Guid clientId, Guid productId, int quantity)
        {
            var investment = await _investmentService.GetByClientIdAndProductIdAsync(clientId, productId);
            if (investment == null || investment.Quantity < quantity)
            {
                throw new InvalidOperationException("Insufficient investment quantity");
            }
            return investment;
        }

        private void ValidateBuyTransaction(ClientDto client, ProductDto product, CreateTransactionDto transactionDto)
        {
            if (product.AvailableQuantity < transactionDto.Quantity)
            {
                throw new InvalidOperationException("Insufficient stock");
            }

            if (product.Price * transactionDto.Quantity > client.Balance)
            {
                throw new InvalidOperationException("Insufficient funds");
            }

            if (product.ExpirationDate < DateTime.Now)
            {
                throw new InvalidOperationException("Product expired");
            }
        }

        private async Task UpdateProductStockAsync(ProductDto product, int quantityChange)
        {
            var updateProductDto = new UpdateProductDto
            {
                Name = product.Name,
                Description = product.Description,
                AvailableQuantity = product.AvailableQuantity + quantityChange,
                Price = product.Price,
                ExpirationDate = product.ExpirationDate
            };

            await _productService.UpdateAsync(product.Id, updateProductDto);
        }

        private async Task UpdateClientBalanceAsync(ClientDto client, decimal balanceChange)
        {
            var updateClientDto = new UpdateClientDto
            {
                Balance = client.Balance + balanceChange
            };
            await _clientService.UpdateClientAsync(client.Id, updateClientDto);
        }

        private async Task<Guid> CreateTransactionAsync(
            Guid clientId,
            ProductDto product,
            CreateTransactionDto transactionDto,
            TransactionType transactionType
        )
        {
            var transaction = _mapper.Map<Transaction>(transactionDto);
            transaction.ClientId = clientId;
            transaction.ProductId = product.Id;
            transaction.UnitPrice = product.Price;
            transaction.TotalPrice = product.Price * transactionDto.Quantity;
            transaction.TransactionType = transactionType;
            await _transactionRepository.AddAsync(transaction);
            return transaction.Id;
        }

        private async Task CreateOrUpdateInvestmentAsync(Guid clientId, Guid productId, int quantity)
        {
            var investment = await _investmentService.GetByClientIdAndProductIdAsync(clientId, productId);

            if (investment == null)
            {
                var createInvestmentDto = new CreateInvestmentDto
                {
                    ClientId = clientId,
                    ProductId = productId,
                    Quantity = quantity
                };
                await _investmentService.AddAsync(createInvestmentDto);
            }
            else
            {
                var updateInvestmentDto = new UpdateInvestmentDto
                {
                    Quantity = investment.Quantity + quantity
                };
                await _investmentService.UpdateAsync(investment.InvestmentId, updateInvestmentDto);
            }
        }

        private async Task UpdateInvestmentAsync(InvestmentDto investment, int quantityChange)
        {
            var updateInvestmentDto = new UpdateInvestmentDto
            {
                Quantity = investment.Quantity + quantityChange
            };
            await _investmentService.UpdateAsync(investment.InvestmentId, updateInvestmentDto);
        }
    }
}
