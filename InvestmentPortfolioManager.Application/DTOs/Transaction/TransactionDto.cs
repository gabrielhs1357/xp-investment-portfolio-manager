using InvestmentPortfolioManager.Domain.Enums;

namespace InvestmentPortfolioManager.Application.DTOs.Transaction
{
    public class TransactionDto
    {
        public Guid TransactionId { get; set; }
        public Guid ProductId { get; set; }
        public required string ProductName { get; set; }
        public TransactionType TransactionType { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
