using InvestmentPortfolioManager.Application.DTOs.Admin;
using InvestmentPortfolioManager.Application.DTOs.Product;
using InvestmentPortfolioManager.Application.Interfaces;

namespace InvestmentPortfolioManager.Worker
{
    public class EmailWorker : BackgroundService
    {
        private readonly ILogger<EmailWorker> _logger;
        private readonly IServiceScopeFactory _scopeFactory;

        public EmailWorker(ILogger<EmailWorker> logger, IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                    using (var scope = _scopeFactory.CreateScope())
                    {
                        var adminService = scope.ServiceProvider.GetRequiredService<IAdminService>();
                        var productService = scope.ServiceProvider.GetRequiredService<IProductService>();
                        var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();

                        var admins = await GetAdmins(adminService);
                        var expiringProducts = await GetExpiringProducts(productService);

                        await emailService.SendEmailAsync(admins, expiringProducts);
                    }
                }
                await Task.Delay(millisecondsDelay: 10000, stoppingToken);
            }
        }

        private async Task<IEnumerable<AdminDto>> GetAdmins(IAdminService adminService)
        {
            var admins = await adminService.GetAllAsync();
            return admins;
        }

        private async Task<IEnumerable<ProductDto>> GetExpiringProducts(IProductService productService)
        {
            var expiringProducts = await productService.GetExpiringProductsAsync();
            return expiringProducts;
        }
    }
}
