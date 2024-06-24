using InvestmentPortfolioManager.Application.Interfaces;
using InvestmentPortfolioManager.Application.Mappings;
using InvestmentPortfolioManager.Application.Services;
using InvestmentPortfolioManager.Domain.Repositories;
using InvestmentPortfolioManager.Infrastructure.Context;
using InvestmentPortfolioManager.Infrastructure.Repositories;
using InvestmentPortfolioManager.Worker;
using Microsoft.EntityFrameworkCore;

var builder = Host.CreateApplicationBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("MainDB");
builder.Services.AddSqlite<ApplicationContext>(connectionString);

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IAdminService, AdminService>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

builder.Services.AddHostedService<EmailWorker>();

var host = builder.Build();
host.Run();
