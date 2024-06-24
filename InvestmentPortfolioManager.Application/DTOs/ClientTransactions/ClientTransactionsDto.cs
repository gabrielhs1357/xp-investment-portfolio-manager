using InvestmentPortfolioManager.Application.DTOs.Transaction;

namespace InvestmentPortfolioManager.Application.DTOs.ClientTransactions
{
    public class ClientTransactionsDto // TODO: move to Client folder?
    {
        public Guid ClientId { get; set; }
        public required string ClientName { get; set; }
        public decimal Balance { get; set; }
        public IEnumerable<TransactionDto>? Transactions { get; set; }
    }
}
