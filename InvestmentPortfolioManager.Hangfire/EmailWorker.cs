using Hangfire;
using InvestmentPortfolioManager.Application.DTOs.Admin;
using InvestmentPortfolioManager.Application.DTOs.Product;
using InvestmentPortfolioManager.Application.Interfaces;

namespace InvestmentPortfolioManager.Hangfire
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
            _logger.LogInformation("Scheduling emails at: {time}", DateTimeOffset.Now);

            using (var scope = _scopeFactory.CreateScope())
            {
                var adminService = scope.ServiceProvider.GetRequiredService<IAdminService>();
                var productService = scope.ServiceProvider.GetRequiredService<IProductService>();
                var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();

                var admins = await GetAdmins(adminService);
                var expiringProducts = await GetExpiringProducts(productService);

                foreach (var admin in admins)
                {
                    var emailTask = new SendEmailTask
                    {
                        Admin = admin,
                        ExpiringProducts = expiringProducts
                    };
                    BackgroundJob.Enqueue(() => emailService.SendIndividualEmailAsync(emailTask));
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

    public class SendEmailTask
    {
        public AdminDto Admin { get; set; }
        public IEnumerable<ProductDto> ExpiringProducts { get; set; }
    }
}
