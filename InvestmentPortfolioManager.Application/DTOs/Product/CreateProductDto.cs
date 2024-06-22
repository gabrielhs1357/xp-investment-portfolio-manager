namespace InvestmentPortfolioManager.Application.DTOs.Product
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int AvailableQuantity { get; set; }
        public decimal Price { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
