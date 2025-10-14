using API.Models;
using BLL.Contracts;
using BLL.DTOs;
using BLL.HobbiesBLL;
using BLL.PsicologoBll;
using BLL.Servicio;
using Data.Contracts;
using Domain.DTO;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PagosController : Controller
    {
        private readonly IPagoService _pagoService;
        private readonly ILogger<PagosController> _logger;
        public PagosController(IPagoService pagoService, ILogger<PagosController> logger)
        {
            _pagoService = pagoService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<Pagos>> RegistrarPago([FromBody] PagoDto pagoDto)
        {
            try
            {
                _logger.LogInformation("Registrando pago para psicólogo: {PsicologoId}", pagoDto.PsicologoId);

                var pago = await _pagoService.RegistrarPagoAsync(pagoDto);

                _logger.LogInformation("Pago registrado exitosamente: {PagoId}", pago.Id);
                return Ok(pago);
                //return CreatedAtAction(nameof(ObtenerPago), new { id = pago.Id }, pago);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "Error de validación al registrar pago");
                return BadRequest(new { error = ex.Message });
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "Recurso no encontrado al registrar pago");
                return NotFound(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error interno al registrar pago");
                return StatusCode(500, new { error = "Error interno del servidor" });
            }
        }
    }
}

