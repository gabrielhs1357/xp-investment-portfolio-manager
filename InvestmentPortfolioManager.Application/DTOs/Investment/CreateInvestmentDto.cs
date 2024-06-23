namespace InvestmentPortfolioManager.Application.DTOs.Investment
{
    public class CreateInvestmentDto
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal AveragePurchasePrice { get; set; }
    }
}
