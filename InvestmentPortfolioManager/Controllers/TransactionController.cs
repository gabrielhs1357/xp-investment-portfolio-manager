using InvestmentPortfolioManager.Application.DTOs.Transaction;
using InvestmentPortfolioManager.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentPortfolioManager.API.Controllers
{
    [ApiController]
    [Route("api/clients/{clientId}/transactions")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionDto>>> GetTransactionsByClientId(Guid clientId)
        {
            var transactions = await _transactionService.GetByClientIdAsync(clientId);
            return Ok(transactions);
        }

        [HttpPost("buy")]
        public async Task<ActionResult<IEnumerable<TransactionDto>>> Buy(
            Guid clientId,
            [FromBody] CreateTransactionDto transactionDto
        )
        {
            var transactionId = await _transactionService.HandleBuyTransactionAsync(clientId, transactionDto);
            return CreatedAtAction(nameof(GetTransactionsByClientId), new { clientId = transactionId }, transactionId);
        }

        [HttpPost("sell")]
        public async Task<ActionResult<IEnumerable<TransactionDto>>> Sell(
            Guid clientId,
            [FromBody] CreateTransactionDto transactionDto
        )
        {
            var transactionId = await _transactionService.HandleSellTransactionAsync(clientId, transactionDto);
            await Console.Out.WriteLineAsync(transactionId.ToString());
            return CreatedAtAction(nameof(GetTransactionsByClientId), new { clientId = transactionId }, transactionId);
        }
    }
}
