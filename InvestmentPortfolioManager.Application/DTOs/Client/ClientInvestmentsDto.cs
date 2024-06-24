using InvestmentPortfolioManager.Application.DTOs.Investment;

namespace InvestmentPortfolioManager.Application.DTOs.Client
{
    public class ClientInvestmentsDto
    {
        public Guid ClientId { get; set; }
        public required string ClientName { get; set; }
        public decimal Balance { get; set; }
        public IEnumerable<InvestmentDto>? Investments { get; set; }
    }
}
