using InvestmentPortfolioManager.Application.DTOs.Investment;
using InvestmentPortfolioManager.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentPortfolioManager.API.Controllers
{
    [ApiController]
    [Route("api/clients/{clientId}/investments")]
    public class InvestmentController : ControllerBase
    {
        private readonly IInvestmentService _investmentService;

        public InvestmentController(IInvestmentService investmentService)
        {
            _investmentService = investmentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvestmentDto>>> GetInvestmentsByClientId(Guid clientId)
        {
            var investments = await _investmentService.GetByClientIdAsync(clientId);
            return Ok(investments);
        }
    }
}
