using AutoMapper;
using InvestmentPortfolioManager.Application.DTOs.Admin;
using InvestmentPortfolioManager.Application.Interfaces;
using InvestmentPortfolioManager.Domain.Entities;
using InvestmentPortfolioManager.Domain.Repositories;

namespace InvestmentPortfolioManager.Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IMapper _mapper;

        public AdminService(IAdminRepository adminRepository, IMapper mapper)
        {
            _adminRepository = adminRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AdminDto>> GetAllAsync()
        {
            var admins = await _adminRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<AdminDto>>(admins);
        }

        public async Task<AdminDto> GetByIdAsync(Guid id)
        {
            var admin = await _adminRepository.GetByIdAsync(id);
            return _mapper.Map<AdminDto>(admin);
        }

        public async Task<Guid> AddAsync(CreateAdminDto adminDto)
        {
            var admin = _mapper.Map<Admin>(adminDto);
            await _adminRepository.AddAsync(admin);
            return admin.Id;
        }
    }
}
