using InvestmentPortfolioManager.Application.DTOs.Product;

namespace InvestmentPortfolioManager.Application.DTOs.Investment
{
    public class InvestmentDto
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public required ProductDto Product { get; set; }
    }
}
