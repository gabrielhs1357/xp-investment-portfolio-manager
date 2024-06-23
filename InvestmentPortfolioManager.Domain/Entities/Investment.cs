namespace InvestmentPortfolioManager.Domain.Entities
{
    public class Investment
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal AveragePurchasePrice { get; set; }
    }
}
