using AutoMapper;
using InvestmentPortfolioManager.Application.DTOs.Admin;
using InvestmentPortfolioManager.Application.DTOs.Client;
using InvestmentPortfolioManager.Application.DTOs.ClientTransactions;
using InvestmentPortfolioManager.Application.DTOs.Investment;
using InvestmentPortfolioManager.Application.DTOs.Product;
using InvestmentPortfolioManager.Application.DTOs.Transaction;
using InvestmentPortfolioManager.Domain.Entities;

namespace InvestmentPortfolioManager.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Transaction, TransactionDto>()
                .ForMember(dest => dest.TransactionId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Product.Id))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.TransactionType, opt => opt.MapFrom(src => src.TransactionType.ToString()))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt));

            CreateMap<ClientDto, ClientTransactionsDto>()
                .ForMember(dest => dest.ClientId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ClientName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.Balance, opt => opt.MapFrom(src => src.Balance))
                .ForMember(dest => dest.Transactions, opt => opt.Ignore());

            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();

            //CreateMap<Transaction, TransactionDto>().ReverseMap();
            CreateMap<Transaction, CreateTransactionDto>().ReverseMap();

            CreateMap<Client, ClientDto>().ReverseMap();
            CreateMap<Client, CreateClientDto>().ReverseMap();

            CreateMap<Investment, InvestmentDto>().ReverseMap();
            CreateMap<Investment, CreateInvestmentDto>().ReverseMap();

            CreateMap<Admin, AdminDto>().ReverseMap();
            CreateMap<Admin, CreateAdminDto>().ReverseMap();
        }
    }
}
