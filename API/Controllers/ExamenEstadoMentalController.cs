
using BLL.Contracts;
using BLL.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ExamenEstadoMentalController : Controller
    {
        private readonly IExamenEstadoMentalService _examenEstadoMentalService;
        private readonly ILogger<ExamenEstadoMentalController> _logger;

        public ExamenEstadoMentalController(
            IExamenEstadoMentalService examenEstadoMentalService,
            ILogger<ExamenEstadoMentalController> logger)
        {
            _examenEstadoMentalService = examenEstadoMentalService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] ExamenEstadoMentalDTO examenEstadoMentalDTO)
        {
            try
            {
                await _examenEstadoMentalService.Crear(examenEstadoMentalDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear Examen de esto mental: {ex.Message}");
            }
        }

        [HttpPut("GetByHistoriaClinica/{Id}")]
        public async Task<IActionResult> GetSignosFisicosById(int Id, [FromBody] ExamenEstadoMentalDTO examenEstadoMentalDTO)
        {
            try
            {
                if (Id == 0) return BadRequest();

                await _examenEstadoMentalService.Actualizar(Id, examenEstadoMentalDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener Examen de estado mental ");
                return StatusCode(500, $"Error al obtener Examen de estado mental: {ex.Message}");
            }
        }

        [HttpGet("GetByHistoriaClinica/{Id}")]
        public async Task<IActionResult> GetByHistoriaClinica(int Id )
        {
            try
            {
                if (Id == 0) return BadRequest();

                var mentalPersonal = await _examenEstadoMentalService.GetByHistoriaClinica(Id);
                return Ok(mentalPersonal);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener Examen de estado mental ");
                return StatusCode(500, $"Error al obtener Examen de estado mental: {ex.Message}");
            }
        }

    }
}

