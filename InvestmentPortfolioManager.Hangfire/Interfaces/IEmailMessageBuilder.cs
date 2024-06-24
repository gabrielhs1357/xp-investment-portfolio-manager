using InvestmentPortfolioManager.Application.DTOs.Admin;
using InvestmentPortfolioManager.Application.DTOs.Product;

namespace InvestmentPortfolioManager.Hangfire.Interfaces
{
    public interface IEmailMessageBuilder
    {
        public string BuildEmailBody(AdminDto admin, IEnumerable<ProductDto> expiringProducts);
    }
}
