namespace InvestmentPortfolioManager.Application.DTOs.Investment
{
    public class InvestmentDto
    {
        public Guid InvestmentId { get; set; }
        public Guid ProductId { get; set; }
        public required string ProductName { get; set; }
        public int Quantity { get; set; }
    }
}
