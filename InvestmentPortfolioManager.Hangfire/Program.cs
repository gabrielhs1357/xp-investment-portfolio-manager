using Hangfire;
using Hangfire.Storage.SQLite;
using InvestmentPortfolioManager.Application.Interfaces;
using InvestmentPortfolioManager.Application.Mappings;
using InvestmentPortfolioManager.Application.Services;
using InvestmentPortfolioManager.Domain.Repositories;
using InvestmentPortfolioManager.Hangfire.Builders;
using InvestmentPortfolioManager.Hangfire.Interfaces;
using InvestmentPortfolioManager.Hangfire.Services;
using InvestmentPortfolioManager.Hangfire.Settings;
using InvestmentPortfolioManager.Hangfire.Workers;
using InvestmentPortfolioManager.Infrastructure.Context;
using InvestmentPortfolioManager.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var hangfireDbConnectionString = builder.Configuration.GetConnectionString("HangfireDB");
var applicationDbConnectionString = builder.Configuration.GetConnectionString("ApplicationDB");

builder.Services.AddSqlite<ApplicationContext>(applicationDbConnectionString);

builder.Services.AddHangfire(configuration => configuration
                .UseRecommendedSerializerSettings()
                .UseSQLiteStorage(hangfireDbConnectionString));

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IAdminService, AdminService>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IEmailMessageBuilder, EmailMessageBuilder>();

//GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute
//{
//    Attempts = 3,
//    DelaysInSeconds = new int[] { 300 }
//});

builder.Services.AddHangfireServer();

var app = builder.Build();

var cronExpression = builder.Configuration.GetSection("HangfireSettings")["CronExpression"];
var brazilTimeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"); // Brasília

app.Lifetime.ApplicationStarted.Register(() =>
{
    RecurringJob.AddOrUpdate<EmailWorker>(
        "ScheduleEmails",
        worker => worker.ScheduleEmailsAsync(),
        cronExpression,
        new RecurringJobOptions
        {
            TimeZone = brazilTimeZone
        });
});

app.UseHangfireDashboard();

app.MapGet(pattern: "/", () => "Ok!");

app.Run();
