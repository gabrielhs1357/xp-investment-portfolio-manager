using InvestmentPortfolioManager.Application.DTOs.Product;
using InvestmentPortfolioManager.Domain.Enums;

namespace InvestmentPortfolioManager.Application.DTOs.Transaction
{
    public class TransactionDto
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public TransactionType TransactionType { get; set; }
        public DateTime CreatedAt { get; set; }
        public required ProductDto Product { get; set; }
    }
}
