using InvestmentPortfolioManager.Application.DTOs.Transaction;

namespace InvestmentPortfolioManager.Application.Interfaces
{
    public interface ITransactionService
    {
        Task<IEnumerable<TransactionDto>> GetByClientIdAsync(Guid clientId);
        Task<Guid> CreateBuyTransactionAsync(Guid clientId, CreateTransactionDto transactionDto);
        Task<Guid> CreateSellTransactionAsync(Guid clientId, CreateTransactionDto transactionDto);
    }
}
