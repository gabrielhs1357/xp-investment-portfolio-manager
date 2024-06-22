using InvestmentPortfolioManager.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace InvestmentPortfolioManager.Infrastructure.Extensions
{
    public static class DataExtensions
    {
        public static async Task MigrateDbAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
            await dbContext.Database.MigrateAsync();
        }
    }
}
