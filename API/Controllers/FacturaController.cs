using API.Models;
using BLL.Contracts;
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
    public class FacturaController : Controller
    {
        private readonly IFacturaService _facturaService;
        private readonly ILogger<FacturaController> _logger;
        public FacturaController(IFacturaService facturaService, ILogger<FacturaController> logger)
        {
            _facturaService = facturaService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CrearFactura([FromBody] FacturaDto facturaDto)
        {

            try
            {
                var factura = await _facturaService.CrearFactura(facturaDto);
                return Ok(factura);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear factura: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetFacturasPaginado([FromQuery] int page = 1, [FromQuery]  int pageSize = 10)
        {
            try
            {
                var facturas = await _facturaService.GetFacturas(page, pageSize);
                return Ok(facturas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener facturas paginadas");
                return StatusCode(500, $"Error al obtener facturas: {ex.Message}");
            }
        }

        [HttpGet("GetPagosbyPaciente")]
        public async Task<IActionResult> GetPagosbyPaciente([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] int idpaciente = 0)
        {
            try
            {
                if (idpaciente == 0 )  return BadRequest();
                
                var facturas = await _facturaService.GetFacturasbyClient(idpaciente, page, pageSize);
                return Ok(facturas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener facturas paginadas");
                return StatusCode(500, $"Error al obtener facturas: {ex.Message}");
            }
        }


        [HttpGet("Download/{IdFactura}")]
        public async Task<IActionResult> DescargarFacturaPdf(int IdFactura)
        {


            var wwwRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "logo.png");
            var pdfBytes = await _facturaService.GenerarFacturaPdf(IdFactura, wwwRootPath);


            return File(pdfBytes, "application/pdf", $"Factura_{DateTime.UtcNow.ToString()}.pdf");
        }

        [HttpGet("PaymethPsychologist")]
        public async Task<IActionResult> PaymethPsychologist([FromQuery] int idPsicologo, [FromQuery] DateTime Fechainicio,
            [FromQuery] DateTime Fechafin, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var facturas = await _facturaService.PaymethPsychologist(idPsicologo, Fechainicio, Fechafin, page, pageSize);
                return Ok(facturas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener los pagos de los psicologos");
                return StatusCode(500, $"Error al obtener los pagos de los psicologos: {ex.Message}");

            }
        }
    }
}

