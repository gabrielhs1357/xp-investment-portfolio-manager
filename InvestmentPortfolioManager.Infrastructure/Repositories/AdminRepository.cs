using InvestmentPortfolioManager.Domain.Entities;
using InvestmentPortfolioManager.Domain.Repositories;
using InvestmentPortfolioManager.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace InvestmentPortfolioManager.Infrastructure.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ApplicationContext _context;

        public AdminRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Admin>> GetAllAsync()
        {
            return await _context.Admins.ToListAsync();
        }

        public async Task<Admin?> GetByIdAsync(Guid id)
        {
            return await _context.Admins.FindAsync(id);
        }

        public async Task AddAsync(Admin admin)
        {
            await _context.Admins.AddAsync(admin);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> EmailExists(string email)
        {
            return await _context.Admins.AnyAsync(a => a.Email == email);
        }
    }
}
