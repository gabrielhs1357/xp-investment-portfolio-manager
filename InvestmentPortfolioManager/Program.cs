using InvestmentPortfolioManager.API.Extensions;
using InvestmentPortfolioManager.Application.Interfaces;
using InvestmentPortfolioManager.Application.Mappings;
using InvestmentPortfolioManager.Application.Services;
using InvestmentPortfolioManager.Domain.Repositories;
using InvestmentPortfolioManager.Infrastructure.Context;
using InvestmentPortfolioManager.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductService, ProductService>();

builder.Services.AddTransient<ITransactionRepository, TransactionRepository>();
builder.Services.AddTransient<ITransactionService, TransactionService>();

builder.Services.AddTransient<IClientRepository, ClientRepository>();
builder.Services.AddTransient<IClientService, ClientService>();

builder.Services.AddTransient<IInvestmentRepository, InvestmentRepository>();
builder.Services.AddTransient<IInvestmentService, InvestmentService>();

builder.Services.AddTransient<IAdminRepository, AdminRepository>();
builder.Services.AddTransient<IAdminService, AdminService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

var connectionString = builder.Configuration.GetConnectionString("MainDB");
builder.Services.AddSqlite<ApplicationContext>(connectionString);

var app = builder.Build();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();
await app.MigrateDbAsync();

app.Run();
