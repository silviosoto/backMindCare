using API.DTOs;
using BLL.Contracts;
using BLL.Servicio;
using Domain.DTO;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PayUController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly PaymentSevices _context;
        private readonly CitasServices _citasServices;
        private readonly SalaSevices _salaSevices;
        private readonly ICarroDeCompraService _carroDeCompraService;


        public PayUController(IConfiguration config, PaymentSevices context,
            CitasServices citasServices,
            ICarroDeCompraService carroDeCompraService,
            SalaSevices salaSevices)
        {
            _config = config;
            _context = context;
            _citasServices = citasServices;
            _salaSevices = salaSevices;
            _carroDeCompraService = carroDeCompraService;
        }

        [HttpPost("firma")]
        public IActionResult GenerarFirma([FromBody] PayuRequestDto dto)
        {
            //var apiKey = _config["PayU:ApiKey"];
            //var merchantId = _config["PayU:MerchantId"];

            var apiKey = "cuM8hUU8eooHoNNQKbcZFajZii";
            var merchantId = "1026554";

            var cadena = $"{apiKey}~{merchantId}~{dto.ReferenceCode}~{dto.Amount:0.00}~COP";

            using var md5 = MD5.Create();
            var bytes = Encoding.UTF8.GetBytes(cadena);
            var hash = md5.ComputeHash(bytes);
            var firma = BitConverter.ToString(hash).Replace("-", "").ToLower();

            return Ok(new { firma });
        }
 
        [HttpPost("confirmation")]
        public async Task<IActionResult> Confirmation()
        {
            string rawBody = string.Empty;

            try
            {
                using var reader = new StreamReader(Request.Body, Encoding.UTF8);
                rawBody = await reader.ReadToEndAsync();

                var firstDecode = WebUtility.UrlDecode(rawBody);
                var secondDecode = WebUtility.UrlDecode(firstDecode); 

                var parsed = HttpUtility.ParseQueryString(secondDecode);
                Console.WriteLine(parsed);
                var confirmation = new PayUConfirmation
                {
                    MerchantId = parsed["merchant_id"],
                    StatePol = parsed["state_pol"],
                    ResponseCodePol = parsed["response_code_pol"],
                    PaymentMethodType = parsed["payment_method_type"],
                    Value = decimal.TryParse(parsed["value"], out var value) ? value : 0,
                    Currency = parsed["currency"],
                    ReferenceSale = parsed["reference_sale"],
                    PaymentDate = DateTime.TryParse(parsed["payment_date"], out var date) ? date : null,
                    RawBody = rawBody
                };

                await _context.Insert(confirmation);
                //El codigo de referencia contiene el ID de la cita
                string reference_code = parsed["reference_sale"];

                string[] listWordReferenceCode = reference_code.Split("_");
                int idCarritoCompra = int.Parse(listWordReferenceCode[1]);

                await _carroDeCompraService.ConfirmarCarritoCompra(idCarritoCompra);
                

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    } 
}
