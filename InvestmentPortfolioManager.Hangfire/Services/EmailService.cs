using InvestmentPortfolioManager.Hangfire.Interfaces;
using InvestmentPortfolioManager.Hangfire.Settings;
using InvestmentPortfolioManager.Hangfire.Tasks;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace InvestmentPortfolioManager.Hangfire.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IOptions<EmailSettings> emailSettings, ILogger<EmailService> logger)
        {
            _emailSettings = emailSettings.Value;
            _logger = logger;
        }

        public async Task SendEmailAsync(SendEmailTask emailTask)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_emailSettings.FromName, _emailSettings.FromEmail));
            emailMessage.To.Add(new MailboxAddress(emailTask.AdminFirstName, emailTask.AdminEmail));
            emailMessage.Subject = "Products Expiring Soon! - InvestmentPortfolioManager";
            emailMessage.Body = new TextPart("plain")
            {
                Text = emailTask.EmailBody
            };

            try
            {
                using (var client = new SmtpClient())
                {
                    _logger.LogInformation($"Sending email to {emailTask.AdminEmail}...");

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
                _logger.LogInformation($"Email sent to {emailTask.AdminEmail}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error sending email to {emailTask.AdminEmail}: {ex.Message}");
                throw; // Re-throw the exception to allow Hangfire to handle retries
            }
        }
    }
}
