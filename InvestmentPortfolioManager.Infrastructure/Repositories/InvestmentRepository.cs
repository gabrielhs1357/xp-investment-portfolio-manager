using InvestmentPortfolioManager.Domain.Entities;
using InvestmentPortfolioManager.Domain.Repositories;
using InvestmentPortfolioManager.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace InvestmentPortfolioManager.Infrastructure.Repositories
{
    public class InvestmentRepository : IInvestmentRepository
    {
        private readonly ApplicationContext _context;


        public InvestmentRepository(ApplicationContext applicationContext)
        {
            _context = applicationContext;
        }

        public async Task AddAsync(Investment investment)
        {
            await _context.Investments.AddAsync(investment);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Investment>> GetByClientIdAsync(Guid clientId)
        {
            return await _context.Investments
                .Where(i => i.ClientId == clientId)
                .Include(i => i.Product)
                .ToListAsync();
        }

        public async Task<Investment?> GetByClientIdAndProductIdAsync(Guid clientId, Guid productId)
        {
            return await _context.Investments
                .Where(i => i.ClientId == clientId && i.ProductId == productId)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Investment investment)
        {
            _context.Investments.Update(investment);
            await _context.SaveChangesAsync();
        }
    }
}
