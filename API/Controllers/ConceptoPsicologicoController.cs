
using BLL.Contracts;
using BLL.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ConceptoPsicologicoController : Controller
    {
        private readonly IConceptoPsicologicoService _conceptoPsicologicoService;
        private readonly ILogger<ConceptoPsicologicoController> _logger;

        public ConceptoPsicologicoController(
            IConceptoPsicologicoService conceptoPsicologicoService,
            ILogger<ConceptoPsicologicoController> logger)
        {
            _conceptoPsicologicoService = conceptoPsicologicoService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] ConceptoPsicologicoDTO conceptoPsicologicoDTO)
        {
            try
            {
                await _conceptoPsicologicoService.Crear(conceptoPsicologicoDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear Concepto Psicologico: {ex.Message}");
            }
        }

        [HttpPut("GetByHistoriaClinica/{Id}")]
        public async Task<IActionResult> GetSignosFisicosById(int Id, [FromBody] ConceptoPsicologicoDTO conceptoPsicologicoDTO)
        {
            try
            {
                if (Id == 0) return BadRequest();

                await _conceptoPsicologicoService.Actualizar(Id, conceptoPsicologicoDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener Concepto Psicologico");
                return StatusCode(500, $"Error al obtener Concepto Psicologico: {ex.Message}");
            }
        }

        [HttpGet("GetByHistoriaClinica/{Id}")]
        public async Task<IActionResult> GetByHistoriaClinica(int Id )
        {
            try
            {
                if (Id == 0) return BadRequest();

                var mentalPersonal = await _conceptoPsicologicoService.GetByHistoriaClinica(Id);
                return Ok(mentalPersonal);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener Concepto Psicologico ");
                return StatusCode(500, $"Error al obtener Concepto Psicologico: {ex.Message}");
            }
        }

    }
}

