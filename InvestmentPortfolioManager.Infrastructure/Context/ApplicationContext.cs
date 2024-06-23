using InvestmentPortfolioManager.Domain.Entities;
using InvestmentPortfolioManager.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace InvestmentPortfolioManager.Infrastructure.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Investment> Investments { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Seed();
        }
    }
}
