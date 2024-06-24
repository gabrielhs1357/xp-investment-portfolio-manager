using System.ComponentModel.DataAnnotations;

namespace InvestmentPortfolioManager.Application.DTOs.Transaction
{
    public class CreateTransactionDto
    {
        [Required]
        public Guid ProductId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
