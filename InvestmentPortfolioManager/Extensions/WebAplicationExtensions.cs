using InvestmentPortfolioManager.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace InvestmentPortfolioManager.API.Extensions
{
    public static class WebAplicationExtensions
    {
        public static async Task MigrateDbAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
            await dbContext.Database.MigrateAsync();
        }
    }
}
