using InvestmentPortfolioManager.Domain.Entities;
using InvestmentPortfolioManager.Domain.Repositories;
using InvestmentPortfolioManager.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace InvestmentPortfolioManager.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext _context;

        public ProductRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product?>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task AddAsync(Product product)
        {
            product.CreatedAt = DateTime.Now; // TODO: set CreatedAt in data extensions
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Product product)
        {
            product.UpdatedAt = DateTime.Now; // TODO: set UpdatedAt in data extensions
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product?>> GetExpiringProductsAsync()
        {
            return await _context.Products.Where(p => p.ExpirationDate <= DateTime.Now.AddDays(30)).ToListAsync();
        }

        public async Task<bool> CodeExists(string code)
        {
            return await _context.Products.AnyAsync(p => p.Code == code);
        }
    }
}
