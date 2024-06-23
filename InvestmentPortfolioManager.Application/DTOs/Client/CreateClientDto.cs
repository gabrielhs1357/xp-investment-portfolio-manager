namespace InvestmentPortfolioManager.Application.DTOs.Client
{
    public class CreateClientDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public decimal Balance { get; set; }
    }
}
