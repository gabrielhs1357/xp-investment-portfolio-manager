using InvestmentPortfolioManager.Application.DTOs.Admin;
using InvestmentPortfolioManager.Application.DTOs.Product;
using InvestmentPortfolioManager.Hangfire.Interfaces;
using System.Text;

namespace InvestmentPortfolioManager.Hangfire.Builders
{
    public class EmailMessageBuilder : IEmailMessageBuilder
    {
        public string BuildEmailBody(AdminDto admin, IEnumerable<ProductDto> expiringProducts)
        {
            var body = new StringBuilder();

            body.AppendLine($"Hello {admin.FirstName},");
            body.AppendLine();
            body.AppendLine("The following products are expiring soon:");
            body.AppendLine();

            foreach (var product in expiringProducts)
            {
                body.AppendLine($"- {product.Name} ({product.Code}): {product.ExpirationDate: dd/MM/yyyy}.");
            }

            return body.ToString();
        }
    }
}
