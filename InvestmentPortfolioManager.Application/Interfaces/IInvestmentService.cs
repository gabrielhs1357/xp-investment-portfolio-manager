using InvestmentPortfolioManager.Application.DTOs.Investment;

namespace InvestmentPortfolioManager.Application.Interfaces
{
    public interface IInvestmentService
    {
        Task<InvestmentDto> GetByClientIdAndProductIdAsync(Guid clientId, Guid productId);
        Task<Guid> AddAsync(CreateInvestmentDto investmentDto);
        Task UpdateAsync(InvestmentDto investmentDto);
    }
}
