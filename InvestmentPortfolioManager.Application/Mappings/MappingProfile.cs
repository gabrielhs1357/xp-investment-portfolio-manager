using AutoMapper;
using InvestmentPortfolioManager.Application.DTOs.Product;
using InvestmentPortfolioManager.Domain.Entities;

namespace InvestmentPortfolioManager.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
        }
    }
}
