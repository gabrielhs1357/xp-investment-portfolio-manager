using Hangfire;
using InvestmentPortfolioManager.Application.DTOs.Admin;
using InvestmentPortfolioManager.Application.DTOs.Product;
using InvestmentPortfolioManager.Application.Interfaces;
using InvestmentPortfolioManager.Hangfire.Interfaces;
using InvestmentPortfolioManager.Hangfire.Tasks;

namespace InvestmentPortfolioManager.Hangfire.Workers
{
    public class EmailWorker
    {
        private readonly ILogger<EmailWorker> _logger;
        private readonly IServiceScopeFactory _scopeFactory;

        public EmailWorker(ILogger<EmailWorker> logger, IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
        }

        public async Task ScheduleEmailsAsync()
        {
            _logger.LogInformation("Enqueuing email tasks at {time}", DateTime.Now);

            using (var scope = _scopeFactory.CreateScope())
            {
                var adminService = scope.ServiceProvider.GetRequiredService<IAdminService>();
                var productService = scope.ServiceProvider.GetRequiredService<IProductService>();
                var emailMessageBuilder = scope.ServiceProvider.GetRequiredService<IEmailMessageBuilder>();

                var admins = await GetAdmins(adminService);
                var expiringProducts = await GetExpiringProducts(productService);

                foreach (var admin in admins)
                {
                    var emailBody = emailMessageBuilder.BuildEmailBody(admin, expiringProducts);

                    var emailTask = new SendEmailTask
                    {
                        AdminEmail = admin.Email,
                        AdminFirstName = admin.FirstName,
                        EmailBody = emailBody
                    };

                    BackgroundJob.Enqueue<IEmailService>(service => service.SendEmailAsync(emailTask));
                }
            }
        }

        private async Task<IEnumerable<AdminDto>> GetAdmins(IAdminService adminService)
        {
            return await adminService.GetAllAsync();
        }

        private async Task<IEnumerable<ProductDto>> GetExpiringProducts(IProductService productService)
        {
            return await productService.GetExpiringProductsAsync();
        }
    }
}
