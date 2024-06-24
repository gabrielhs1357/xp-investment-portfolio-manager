using InvestmentPortfolioManager.Application.DTOs.Client;
using InvestmentPortfolioManager.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentPortfolioManager.API.Controllers
{
    [ApiController]
    [Route("api/clients/{clientId}/investments")]
    public class InvestmentController : ControllerBase
    {
        private readonly IInvestmentService _investmentService;
        private readonly IClientService _clientService;

        public InvestmentController(IInvestmentService investmentService, IClientService clientService)
        {
            _investmentService = investmentService;
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientInvestmentsDto>>> GetInvestmentsByClientId(Guid clientId)
        {
            var client = await _clientService.GetByIdAsync(clientId);

            if (client == null)
            {
                return NotFound("Client not found");
            }

            var investments = await _investmentService.GetByClientIdAsync(clientId);

            var clientInvestments = _clientService.MapClientInvestmentsDto(client, investments);

            return Ok(clientInvestments);
        }
    }
}
