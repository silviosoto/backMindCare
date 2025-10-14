
using BLL.Contracts;
using BLL.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HistoriaClinicaController : Controller
    {
        private readonly IHistoriaClinicaService _historiaClinicaService;
        private readonly ILogger<HistoriaClinicaController> _logger;


        public HistoriaClinicaController(IHistoriaClinicaService historiaClinicaService,
            ILogger<HistoriaClinicaController> logger)
        {
            _historiaClinicaService = historiaClinicaService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CrearHistoriaClinica([FromBody] HistoriaClinicaCreateDto historiaClinicaDTO)
        {
            try
            {
                await _historiaClinicaService.CrearHistoriaClinica(historiaClinicaDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear Historia clinica: {ex.Message}");
            }
        }

        [HttpGet("GetHistoriaClinicaById")]
        public async Task<IActionResult> GetHistoriaClinicaById([FromQuery] int IdPaciente)
        {
            try
            {
                if (IdPaciente == 0 )  return BadRequest();
                
                var historiaClinica = await _historiaClinicaService.GetHistoriaClinicaById(IdPaciente);
                return Ok(historiaClinica);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener Historia clinica ");
                return StatusCode(500, $"Error al obtener Historia clinica: {ex.Message}");
            }
        }
         
    }
}

