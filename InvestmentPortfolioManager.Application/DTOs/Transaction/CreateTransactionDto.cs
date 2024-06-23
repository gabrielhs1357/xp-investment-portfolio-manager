using InvestmentPortfolioManager.Domain.Enums;

namespace InvestmentPortfolioManager.Application.DTOs.Transaction
{
    public class CreateTransactionDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
