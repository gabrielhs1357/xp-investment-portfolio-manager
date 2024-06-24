using InvestmentPortfolioManager.Application.DTOs.Client;
using InvestmentPortfolioManager.Application.Interfaces;
using InvestmentPortfolioManager.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentPortfolioManager.API.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientDto>>> GetClients()
        {
            var clients = await _clientService.GetAllAsync();

            if (clients == null)
            {
                return NoContent();
            }

            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ClientDto>>> GetClientById(Guid id)
        {
            var client = await _clientService.GetByIdAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        [HttpPost]
        public async Task<ActionResult<ClientDto>> CreateClient([FromBody] CreateClientDto clientDto)
        {
            if (await _clientService.EmailExists(clientDto.Email))
            {
                return Conflict("Email already exists");
            }

            var clientId = await _clientService.AddAsync(clientDto);

            return CreatedAtAction(nameof(GetClientById), new { id = clientId }, clientId);
        }
    }
}
