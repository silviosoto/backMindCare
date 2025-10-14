using BLL.Contracts;
using BLL.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoDeCompraController : Controller
    {
        private readonly ICarroDeCompraService _carroDeCompraService;
        private readonly ILogger<CarritoDeCompraController> _logger;
        public CarritoDeCompraController(ICarroDeCompraService carroDeCompraService,
            ILogger<CarritoDeCompraController> logger)
        {
            _carroDeCompraService = carroDeCompraService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CrearCarritoDeCompra([FromBody] CarritoDeComraCreateDTO CarritoDeComraCreateDTO)
        {
            try
            {
                int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int idUser) ;
                
                var factura = await _carroDeCompraService.Crear(CarritoDeComraCreateDTO, idUser);
                return Ok(factura);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear carrito de compras: {ex.Message}");
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> CrearCarritoDeCompra(int idCarrito)
        {
            try
            {
                var factura = await _carroDeCompraService.ConfirmarCarritoCompra( idCarrito );
                return Ok(factura);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al confirmar carrito de compras: {ex.Message}");
            }
        }

    }
}

