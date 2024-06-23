using InvestmentPortfolioManager.Domain.Entities;
using InvestmentPortfolioManager.Infrastructure.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InvestmentPortfolioManager.Infrastructure.Extensions
{
    public static class DataExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasData(
                new Client
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Gabriel",
                    LastName = "Silva",
                    Email = "gabriel123@gmail.com",
                    Balance = 10000
                },
                new Client
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Henrique",
                    LastName = "Silveira",
                    Email = "henrique123@gmail.com",
                    Balance = 20000
                },
                new Client
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Thiago",
                    LastName = "Silva",
                    Email = "thiago123@gmail.com",
                    Balance = 30000
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 1",
                    Code = "PDT1",
                    Description = "Product 1 description",
                    AvailableQuantity = 10,
                    Price = 100,
                    ExpirationDate = DateTime.Now.AddDays(30),
                    UpdatedAt = null,
                    CreatedAt = DateTime.Now
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 2",
                    Code = "PDT2",
                    Description = "Product 2 description",
                    AvailableQuantity = 20,
                    Price = 200,
                    ExpirationDate = DateTime.Now.AddDays(15),
                    UpdatedAt = null,
                    CreatedAt = DateTime.Now
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 3",
                    Code = "PDT3",
                    Description = "Product 3 description",
                    AvailableQuantity = 30,
                    Price = 300,
                    ExpirationDate = DateTime.Now.AddHours(1),
                    UpdatedAt = null,
                    CreatedAt = DateTime.Now
                }
            );
        }

        public static async Task MigrateDbAsync(this WebApplication app) // TODO: migrate to API layer
        {
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
            await dbContext.Database.MigrateAsync();
        }
    }
}
