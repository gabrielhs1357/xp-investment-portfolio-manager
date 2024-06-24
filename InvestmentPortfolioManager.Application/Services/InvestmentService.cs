using AutoMapper;
using InvestmentPortfolioManager.Application.DTOs.Investment;
using InvestmentPortfolioManager.Application.DTOs.Product;
using InvestmentPortfolioManager.Application.Interfaces;
using InvestmentPortfolioManager.Domain.Entities;
using InvestmentPortfolioManager.Domain.Repositories;

namespace InvestmentPortfolioManager.Application.Services
{
    public class InvestmentService : IInvestmentService
    {
        private readonly IInvestmentRepository _investmentRepository;
        private readonly IMapper _mapper;

        public InvestmentService(IInvestmentRepository investmentRepository, IMapper mapper)
        {
            _investmentRepository = investmentRepository;
            _mapper = mapper;
        }

        public async Task<Guid> AddAsync(CreateInvestmentDto investmentDto)
        {
            var investment = _mapper.Map<Investment>(investmentDto);

            await _investmentRepository.AddAsync(investment);

            return investment.Id;
        }

        public async Task<IEnumerable<InvestmentDto>> GetByClientIdAsync(Guid clientId)
        {
            var investments = await _investmentRepository.GetByClientIdAsync(clientId);
            return _mapper.Map<IEnumerable<InvestmentDto>>(investments);
        }

        public async Task<InvestmentDto> GetByClientIdAndProductIdAsync(Guid clientId, Guid productId)
        {
            var investment = await _investmentRepository.GetByClientIdAndProductIdAsync(clientId, productId);
            return _mapper.Map<InvestmentDto>(investment);
        }

        public async Task UpdateAsync(Guid id, UpdateInvestmentDto investmentDto)
        {
            var investment = await _investmentRepository.GetByIdAsync(id);

            if (investment == null)
            {
                throw new InvalidOperationException("Investment not found"); // throw a BadRequestException
            }

            _mapper.Map(investmentDto, investment);

            await _investmentRepository.UpdateAsync(investment);
        }
    }
}
