namespace InvestmentPortfolioManager.Application.DTOs.Client
{
    public class ClientDto
    {
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public decimal Balance { get; set; }
    }
}
