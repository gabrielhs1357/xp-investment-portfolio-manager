using InvestmentPortfolioManager.Application.DTOs.Transaction;

namespace InvestmentPortfolioManager.Application.Interfaces
{
    public interface ITransactionService
    {
        Task<IEnumerable<TransactionDto>> GetByClientIdAsync(Guid clientId);
        Task<Guid> HandleBuyTransactionAsync(Guid clientId, CreateTransactionDto transactionDto);
        Task<Guid> HandleSellTransactionAsync(Guid clientId, CreateTransactionDto transactionDto);
    }
}
