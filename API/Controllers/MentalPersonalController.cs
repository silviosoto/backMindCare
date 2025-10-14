
using BLL.Contracts;
using BLL.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MentalPersonalController : Controller
    {
        private readonly IMentalPersonalService _sentalPersonalService;
        private readonly ILogger<MentalPersonalController> _logger;

        public MentalPersonalController(
            IMentalPersonalService sentalPersonalService,
            ILogger<MentalPersonalController> logger)
        {
            _sentalPersonalService = sentalPersonalService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] MentalPersonalDTO mentalPersonalDTO)
        {
            try
            {
                await _sentalPersonalService.Crear(mentalPersonalDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear Mental Personal: {ex.Message}");
            }
        }

        [HttpPut("GetByHistoriaClinica/{Id}")]
        public async Task<IActionResult> GetSignosFisicosById(int Id, [FromBody] MentalPersonalDTO mentalPersonalDTO)
        {
            try
            {
                if (Id == 0) return BadRequest();

                await _sentalPersonalService.Actualizar(Id, mentalPersonalDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener Mental Personal ");
                return StatusCode(500, $"Error al obtener Mental Personal: {ex.Message}");
            }
        }

        [HttpGet("GetByHistoriaClinica/{Id}")]
        public async Task<IActionResult> GetByHistoriaClinica(int Id )
        {
            try
            {
                if (Id == 0) return BadRequest();

                var mentalPersonal = await _sentalPersonalService.GetByHistoriaClinica(Id);
                return Ok(mentalPersonal);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener Mental Personal ");
                return StatusCode(500, $"Error al obtener Mental Personal: {ex.Message}");
            }
        }

    }
}

