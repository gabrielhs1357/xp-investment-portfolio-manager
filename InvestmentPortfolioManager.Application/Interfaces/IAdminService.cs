using InvestmentPortfolioManager.Application.DTOs.Admin;

namespace InvestmentPortfolioManager.Application.Interfaces
{
    public interface IAdminService
    {
        Task<IEnumerable<AdminDto>> GetAllAsync();
        Task<AdminDto> GetByIdAsync(Guid id);
        Task<Guid> AddAsync(CreateAdminDto createAdminDto);
        Task<bool> EmailExists(string email);
    }
}
