using InvestmentPortfolioManager.Application.DTOs.Transaction;
using InvestmentPortfolioManager.Application.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
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
        public async Task<ActionResult<IEnumerable<TransactionDto>>> CreateBuyTransaction(
            Guid clientId,
            [FromBody] CreateTransactionDto transactionDto
        )
        {
            var transactionId = await _transactionService.CreateBuyTransactionAsync(clientId, transactionDto);
            return CreatedAtAction(nameof(GetTransactionsByClientId), new { clientId = transactionId }, transactionId);
        }

        [HttpPost("sell")]
        public async Task<ActionResult<IEnumerable<TransactionDto>>> CreateSellTransaction(
            Guid clientId,
            [FromBody] CreateTransactionDto transactionDto
        )
        {
            var transactionId = await _transactionService.CreateSellTransactionAsync(clientId, transactionDto);
            await Console.Out.WriteLineAsync(transactionId.ToString());
            return CreatedAtAction(nameof(GetTransactionsByClientId), new { clientId = transactionId }, transactionId);
        }
    }
}
