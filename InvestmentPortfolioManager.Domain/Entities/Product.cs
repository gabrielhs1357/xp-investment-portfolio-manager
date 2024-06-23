namespace InvestmentPortfolioManager.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int AvailableQuantity { get; set; }
        public decimal Price { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
