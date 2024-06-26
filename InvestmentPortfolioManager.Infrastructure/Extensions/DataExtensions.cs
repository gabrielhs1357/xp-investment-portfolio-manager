﻿using InvestmentPortfolioManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvestmentPortfolioManager.Infrastructure.Extensions
{
    public static class DataExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    Id = Guid.Parse("b567f04c-68f4-49cd-929e-c5933c5227b8"),
                    FirstName = "Gabriel",
                    LastName = "Silva",
                    Email = "gabrielhs1357@gmail.com"
                });

            modelBuilder.Entity<Client>().HasData(
                new Client
                {
                    Id = Guid.Parse("752a9e0d-3586-4ff2-8b1f-dbb7c6779d43"),
                    FirstName = "Henrique",
                    LastName = "Silva",
                    Email = "henrique123@gmail.com",
                    Balance = 1000
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = Guid.Parse("7cf4812a-3344-427a-a94d-dfd97d862ee3"),
                    Name = "Product 1",
                    Code = "PDT1",
                    Description = "Not expiring!",
                    AvailableQuantity = 10,
                    Price = 100,
                    ExpirationDate = DateTime.Now.AddDays(60),
                    UpdatedAt = null,
                    CreatedAt = DateTime.Now
                },
                new Product
                {
                    Id = Guid.Parse("e8c50f0a-62a7-432f-a3fd-bd44c6d913c0"),
                    Name = "Product 2",
                    Code = "PDT2",
                    Description = "Expiring soon!",
                    AvailableQuantity = 10,
                    Price = 100,
                    ExpirationDate = DateTime.Now.AddHours(15),
                    UpdatedAt = null,
                    CreatedAt = DateTime.Now
                }
            );

            modelBuilder.Entity<Transaction>().HasData(
                new Transaction
                {
                    Id = Guid.Parse("1cd4fadf-08c6-4d5e-9d5d-b0aebc61304c"),
                    ClientId = Guid.Parse("752a9e0d-3586-4ff2-8b1f-dbb7c6779d43"),
                    ProductId = Guid.Parse("e8c50f0a-62a7-432f-a3fd-bd44c6d913c0"),
                    Quantity = 10,
                    UnitPrice = 100,
                    TotalPrice = 1000,
                    TransactionType = Domain.Enums.TransactionType.Buy,
                    CreatedAt = DateTime.Now.AddHours(-1)
                },
                new Transaction
                {
                    Id = Guid.Parse("309ffbc9-2506-427c-bd99-dac517693a24"),
                    ClientId = Guid.Parse("752a9e0d-3586-4ff2-8b1f-dbb7c6779d43"),
                    ProductId = Guid.Parse("e8c50f0a-62a7-432f-a3fd-bd44c6d913c0"),
                    Quantity = 10,
                    UnitPrice = 100,
                    TotalPrice = 1000,
                    TransactionType = Domain.Enums.TransactionType.Sell,
                    CreatedAt = DateTime.Now.AddMinutes(-30)
                }
            );

            modelBuilder.Entity<Investment>().HasData(
                new Investment
                {
                    Id = Guid.Parse("f1b3b3b4-1b3b-4b3b-8b3b-3b3b3b3b3b3b"),
                    ClientId = Guid.Parse("752a9e0d-3586-4ff2-8b1f-dbb7c6779d43"),
                    ProductId = Guid.Parse("7cf4812a-3344-427a-a94d-dfd97d862ee3"),
                    Quantity = 10
                }
            );
        }
    }
}
