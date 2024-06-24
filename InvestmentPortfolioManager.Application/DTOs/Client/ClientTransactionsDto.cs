using InvestmentPortfolioManager.Application.DTOs.Transaction;

namespace InvestmentPortfolioManager.Application.DTOs.Client
{
    public class ClientTransactionsDto
    {
        public Guid ClientId { get; set; }
        public required string ClientName { get; set; }
        public decimal Balance { get; set; }
        public IEnumerable<TransactionDto>? Transactions { get; set; }
    }
}
