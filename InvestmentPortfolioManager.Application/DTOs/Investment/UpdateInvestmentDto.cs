using System.ComponentModel.DataAnnotations;

namespace InvestmentPortfolioManager.Application.DTOs.Investment
{
    public class UpdateInvestmentDto
    {
        [Required]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
