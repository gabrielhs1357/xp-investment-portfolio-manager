using InvestmentPortfolioManager.Application.DTOs.Admin;
using InvestmentPortfolioManager.Application.DTOs.Product;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace InvestmentPortfolioManager.Worker
{
    public class EmailSettings
    {
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUser { get; set; }
        public string SmtpPass { get; set; }
        public string FromEmail { get; set; }
    }

    public interface IEmailService
    {
        Task SendEmailAsync(IEnumerable<AdminDto> admins, IEnumerable<ProductDto> expiringProducts);
    }

    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;
        private readonly ILogger<EmailService> _logger;

        public EmailService(
            ILogger<EmailService> logger,
            IOptions<EmailSettings> emailSettings
        )
        {
            _logger = logger;
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(IEnumerable<AdminDto> admins, IEnumerable<ProductDto> expiringProducts)
        {
            var subject = "Products Expiring Soon! - InvestmentPortfolioManager";
            var productsExpiring = string.Empty;

            foreach (var product in expiringProducts)
            {
                productsExpiring += $"- {product.Name} ({product.Code}): expires on {product.ExpirationDate}.\n";
            }

            foreach (var admin in admins)
            {
                var message = $"Hello {admin.FirstName},\n\n" +
                    $"The following products are expiring soon:\n\n" +
                    $"{productsExpiring}\n" +
                    "Please take the necessary actions to renew or cancel these products.\n\n" +
                    "Thank you,\n\n" +
                    "- InvestmentPortfolioManager";

                var emailMessage = new MimeMessage();

                emailMessage.From.Add(new MailboxAddress("InvestmentPortfolioManager", _emailSettings.FromEmail));
                emailMessage.To.Add(new MailboxAddress(admin.FirstName, admin.Email));
                emailMessage.Subject = subject;
                emailMessage.Body = new TextPart("plain")
                {
                    Text = message
                };

                try
                {
                    _logger.LogInformation($"Email message: {emailMessage}");

                    using (var client = new SmtpClient())
                    {
                        client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                        _logger.LogInformation($"Connecting to SMTP server...");
                        await client.ConnectAsync(_emailSettings.SmtpServer, _emailSettings.SmtpPort, SecureSocketOptions.StartTls);

                        _logger.LogInformation($"Authenticating...");
                        await client.AuthenticateAsync(_emailSettings.SmtpUser, _emailSettings.SmtpPass);

                        _logger.LogInformation($"Sending email to {admin.Email}...");
                        await client.SendAsync(emailMessage);

                        _logger.LogInformation($"Disconnecting from SMTP server...");
                        await client.DisconnectAsync(true);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error sending email to {admin.Email}: {ex.Message}");
                    throw;
                }
            }
        }
    }
}
