
using BLL.Contracts;
using BLL.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SignosFisicosController : Controller
    {
        private readonly ISignosFisicosService _signosFisicosService;
        private readonly ILogger<SignosFisicosController> _logger;


        public SignosFisicosController(ISignosFisicosService signosFisicosService,
            ILogger<SignosFisicosController> logger)
        {
            _signosFisicosService = signosFisicosService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CrearSignosFisicos([FromBody] SignosFisicosDTO signosFisicosCreateDTO)
        {
            try
            {
                await _signosFisicosService.CrearSignosFisicos(signosFisicosCreateDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear Signos Fisicos: {ex.Message}");
            }
        }

        [HttpPut("GetByHistoriaClinica/{Id}")]
        public async Task<IActionResult> GetSignosFisicosById(int Id, [FromBody] SignosFisicosDTO signosFisicosCreateDTO)
        {
            try
            {
                if (Id == 0) return BadRequest();

                await _signosFisicosService.ActualizarSignosFisicos(Id, signosFisicosCreateDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener Signos Fisicos ");
                return StatusCode(500, $"Error al obtener Signos Fisicos: {ex.Message}");
            }
        }

    }
}

