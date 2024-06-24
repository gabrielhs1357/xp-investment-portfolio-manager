using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace InvestmentPortfolioManager.Hangfire
{
    public class EmailSettings
    {
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUser { get; set; }
        public string SmtpPass { get; set; }
        public string FromEmail { get; set; }
        public string FromName { get; set; }
    }

    public interface IEmailService
    {
        Task SendIndividualEmailAsync(SendEmailTask emailTask);
    }

    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IOptions<EmailSettings> emailSettings, ILogger<EmailService> logger)
        {
            _emailSettings = emailSettings.Value;
            _logger = logger;
        }

        public async Task SendIndividualEmailAsync(SendEmailTask emailTask)
        {
            var admin = emailTask.Admin;
            var expiringProducts = emailTask.ExpiringProducts;

            var subject = "Products Expiring Soon! - InvestmentPortfolioManager";
            var message = $"Hi {admin.FirstName}! The following products are expiring soon:\n\n";

            foreach (var product in expiringProducts)
            {
                message += $"- {product.Name} ({product.Code}): expires on {product.ExpirationDate}.\n";
            }

            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(_emailSettings.FromName, _emailSettings.FromEmail));
            emailMessage.To.Add(new MailboxAddress(admin.FirstName, admin.Email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("plain") { Text = message };

            try
            {
                using (var client = new SmtpClient())
                {
                    _logger.LogInformation($"Sending email to {admin.Email}...");

                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    await client.ConnectAsync(
                        _emailSettings.SmtpServer,
                        _emailSettings.SmtpPort,
                        MailKit.Security.SecureSocketOptions.StartTls
                    );

                    _logger.LogInformation($"Authenticating...");
                    await client.AuthenticateAsync(_emailSettings.SmtpUser, _emailSettings.SmtpPass);

                    _logger.LogInformation($"Sending email...");
                    await client.SendAsync(emailMessage);

                    _logger.LogInformation($"Disconnecting from SMTP server...");
                    await client.DisconnectAsync(true);
                }
                _logger.LogInformation($"Email sent to {admin.Email}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error sending email to {admin.Email}: {ex.Message}");
                throw; // Re-throw the exception to allow Hangfire to handle retries
            }
        }
    }
}
