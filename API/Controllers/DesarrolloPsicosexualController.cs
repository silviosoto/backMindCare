
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
    public class DesarrolloPsicosexualController : Controller
    {
        private readonly IDesarrolloPsicosexualService _desarrolloPsicosexualService;
        private readonly ILogger<DesarrolloPsicosexualController> _logger;


        public DesarrolloPsicosexualController(
            IDesarrolloPsicosexualService desarrolloPsicosexualService,
            ILogger<DesarrolloPsicosexualController> logger)
        {
            _desarrolloPsicosexualService = desarrolloPsicosexualService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] DesarrolloPsicosexualDTO desarrolloPsicosexualDTO)
        {
            try
            {
                await _desarrolloPsicosexualService.Crear(desarrolloPsicosexualDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear Historia academica: {ex.Message}");
            }
        }

        [HttpPut("GetByHistoriaClinica/{Id}")]
        public async Task<IActionResult> GetById(int Id, [FromBody] DesarrolloPsicosexualDTO desarrolloPsicosexualDTO)
        {
            try
            {
                if (Id == 0) return BadRequest();

                await _desarrolloPsicosexualService.Actualizar(Id, desarrolloPsicosexualDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener desarrollo psicosexual ");
                return StatusCode(500, $"Error al obtener Historia academica: {ex.Message}");
            }
        }

        [HttpGet("GetByHistoriaClinica/{Id}")]
        public async Task<IActionResult> GetByHistoriaClinica(int Id)
        {
            try
            {
                if (Id == 0) return BadRequest();

                var mentalPersonal = await _desarrolloPsicosexualService.GetByHistoriaClinica(Id);
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

