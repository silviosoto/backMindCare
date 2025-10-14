
using BLL;
using BLL.Contracts;
using BLL.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HistoriaAcademicaController : Controller
    {
        private readonly IHistoriaAcademicaService _historiaAcademicaService;
        private readonly ILogger<HistoriaAcademicaController> _logger;


        public HistoriaAcademicaController(
            IHistoriaAcademicaService historiaAcademicaService,
            ILogger<HistoriaAcademicaController> logger)
        {
            _historiaAcademicaService = historiaAcademicaService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] HistoriaAcademicaDTO historiaAcademicaDTO)
        {
            try
            {
                await _historiaAcademicaService.Crear(historiaAcademicaDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear Historia academica: {ex.Message}");
            }
        }

        [HttpPut("GetByHistoriaClinica/{Id}")]
        public async Task<IActionResult> GetById(int Id, [FromBody] HistoriaAcademicaDTO historiaAcademicaDTO)
        {
            try
            {
                if (Id == 0) return BadRequest();

                await _historiaAcademicaService.Actualizar(Id, historiaAcademicaDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener Historia academica ");
                return StatusCode(500, $"Error al obtener Historia academica: {ex.Message}");
            }
        }

        [HttpGet("GetByHistoriaClinica/{Id}")]
        public async Task<IActionResult> GetByHistoriaClinica(int Id)
        {
            try
            {
                if (Id == 0) return BadRequest();

                var mentalPersonal = await _historiaAcademicaService.GetByHistoriaClinica(Id);
                return Ok(mentalPersonal);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener Historia academica ");
                return StatusCode(500, $"Error al obtener Historia academica: {ex.Message}");
            }
        }

    }
}

