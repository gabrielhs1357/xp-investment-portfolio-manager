﻿using AutoMapper;
using InvestmentPortfolioManager.Application.DTOs.Product;
using InvestmentPortfolioManager.Application.DTOs.Transaction;
using InvestmentPortfolioManager.Domain.Entities;

namespace InvestmentPortfolioManager.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();

            CreateMap<Transaction, TransactionDto>().ReverseMap();
            CreateMap<Transaction, CreateTransactionDto>().ReverseMap();
        }
    }
}
