using System.ComponentModel.DataAnnotations;

namespace InvestmentPortfolioManager.Application.DTOs.Product
{
    public class UpdateProductDto
    {
        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        [Required]
        [StringLength(100)]
        public string? Description { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int AvailableQuantity { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }
    }
}
