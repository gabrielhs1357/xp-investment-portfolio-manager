using System.ComponentModel.DataAnnotations;

namespace InvestmentPortfolioManager.Application.DTOs.Client
{
    public class UpdateClientDto
    {
        [Required]
        [Range(0, double.MaxValue)]
        public decimal Balance { get; set; }
    }
}
