using InvestmentPortfolioManager.Application.DTOs.ClientTransactions;
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
        private readonly IClientService _clientService;

        public TransactionController(ITransactionService transactionService, IClientService clientService)
        {
            _transactionService = transactionService;
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientTransactionsDto>>> GetTransactionsByClientId(Guid clientId)
        {
            var client = await _clientService.GetByIdAsync(clientId);

            if (client == null)
            {
                return NotFound("Client not found");
            }

            var transactions = await _transactionService.GetByClientIdAsync(clientId);

            var clientTransactions = _clientService.MapClientTransactionsDto(client, transactions);

            return Ok(clientTransactions);
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
