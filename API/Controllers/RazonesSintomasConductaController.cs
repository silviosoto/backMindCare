
using BLL.Contracts;
using BLL.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RazonesSintomasConductaController : Controller
    {
        private readonly IRazonesSintomasConductaService _razonesSintomasConductaService;
        private readonly ILogger<RazonesSintomasConductaController> _logger;

        public RazonesSintomasConductaController(
            IRazonesSintomasConductaService razonesSintomasConductaService,
            ILogger<RazonesSintomasConductaController> logger)
        {
            _razonesSintomasConductaService = razonesSintomasConductaService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] RazonesSintomasConductaDTO razonesSintomasConductaDTO)
        {
            try
            {
                await _razonesSintomasConductaService.Crear(razonesSintomasConductaDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear razones sintomas conducta: {ex.Message}");
            }
        }

        [HttpPut("GetByHistoriaClinica/{Id}")]
        public async Task<IActionResult> GetSignosFisicosById(int Id, [FromBody] RazonesSintomasConductaDTO razonesSintomasConductaDTO)
        {
            try
            {
                if (Id == 0) return BadRequest();

                await _razonesSintomasConductaService.Actualizar(Id, razonesSintomasConductaDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener razones de conducta ");
                return StatusCode(500, $"Error al obtener razones de conducta: {ex.Message}");
            }
        }

        [HttpGet("GetByHistoriaClinica/{Id}")]
        public async Task<IActionResult> GetByHistoriaClinica(int Id )
        {
            try
            {
                if (Id == 0) return BadRequest();

                var razonesSintomasConducta = await _razonesSintomasConductaService.GetByHistoriaClinica(Id);
                return Ok(razonesSintomasConducta);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener Mental Personal ");
                return StatusCode(500, $"Error al obtener Mental Personal: {ex.Message}");
            }
        }

    }
}

