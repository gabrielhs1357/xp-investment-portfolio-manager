using InvestmentPortfolioManager.Hangfire.Tasks;

namespace InvestmentPortfolioManager.Hangfire.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(SendEmailTask emailTask);
    }
}
