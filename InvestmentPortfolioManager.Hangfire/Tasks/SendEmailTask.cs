namespace InvestmentPortfolioManager.Hangfire.Tasks
{
    public class SendEmailTask
    {
        public string AdminEmail { get; set; }
        public string AdminFirstName { get; set; }
        public string EmailBody { get; set; }
    }
}
