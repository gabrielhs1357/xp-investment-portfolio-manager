using InvestmentPortfolioManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvestmentPortfolioManager.Infrastructure.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(MainContext).Assembly);

            //modelBuilder.Entity<Product>(entity =>
            //{
            //    entity.HasKey(e => e.Id);
            //    entity.Property(e => e.Name).IsRequired();
            //    entity.Property(e => e.Code).IsRequired();
            //    entity.Property(e => e.Description).IsRequired();
            //    entity.Property(e => e.AvailableQuantity).IsRequired();
            //    entity.Property(e => e.Price).IsRequired();
            //    entity.Property(e => e.IsActive).HasDefaultValue(true);
            //    entity.Property(e => e.CreatedAt).HasDefaultValue(DateTime.Now);
            //    entity.Property(e => e.UpdatedAt);
            //});

            //modelBuilder.Entity<Product>().HasData(
            //    new Product { 
            //        Id = Guid.NewGuid(),
            //        Name = "Product 1",
            //        Code = "P1",
            //        Description = "Description 1",
            //        AvailableQuantity = 100,
            //        Price = 100,
            //        IsActive = true,
            //        CreatedAt = DateTime.Now,
            //        UpdatedAt = DateTime.Now
            //    }
            //);
        }
    }
}
