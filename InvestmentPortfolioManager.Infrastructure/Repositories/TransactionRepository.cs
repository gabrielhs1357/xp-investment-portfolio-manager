using InvestmentPortfolioManager.Domain.Entities;
using InvestmentPortfolioManager.Domain.Repositories;
using InvestmentPortfolioManager.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace InvestmentPortfolioManager.Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationContext _context;

        public TransactionRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Transaction>> GetByClientIdAsync(Guid clientId)
        {
            var transactions = await _context.Transactions
                .Where(t => t.ClientId == clientId)
                .Include(t => t.Product)
                .ToListAsync();
            return transactions;
        }

        public async Task AddAsync(Transaction trasaction)
        {
            await _context.Transactions.AddAsync(trasaction);
            await _context.SaveChangesAsync();
        }
    }
}
