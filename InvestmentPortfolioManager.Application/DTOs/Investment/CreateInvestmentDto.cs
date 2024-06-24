using System.ComponentModel.DataAnnotations;

namespace InvestmentPortfolioManager.Application.DTOs.Investment
{
    public class CreateInvestmentDto
    {
        [Required]
        public Guid ClientId { get; set; }

        [Required]
        public Guid ProductId { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
