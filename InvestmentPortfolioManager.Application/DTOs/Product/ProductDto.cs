namespace InvestmentPortfolioManager.Application.DTOs.Product
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; } 
        public string Description { get; set; }
        public int AvailableQuantity { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime Created { get; set; }
    }
}
