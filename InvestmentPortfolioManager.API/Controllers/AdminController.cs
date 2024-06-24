using InvestmentPortfolioManager.Application.DTOs.Admin;
using InvestmentPortfolioManager.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentPortfolioManager.API.Controllers
{
    [ApiController]
    [Route("api/admins")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminDto>>> GetAdmins()
        {
            var admins = await _adminService.GetAllAsync();

            if (admins == null)
            {
                return NoContent();
            }

            return Ok(admins);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<AdminDto>>> GetAdminById(Guid id)
        {
            var admin = await _adminService.GetByIdAsync(id);

            if (admin == null)
            {
                return NotFound();
            }

            return Ok(admin);
        }

        [HttpPost]
        public async Task<ActionResult<AdminDto>> CreateAdmin([FromBody] CreateAdminDto adminDto)
        {
            if (await _adminService.EmailExists(adminDto.Email))
            {
                return Conflict("Email already exists");
            }

            var adminId = await _adminService.AddAsync(adminDto);

            return CreatedAtAction(nameof(GetAdminById), new { id = adminId }, adminId);
        }
    }
}
