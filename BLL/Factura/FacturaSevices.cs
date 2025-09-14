using API.Models;
using AutoMapper; 
using BLL.Contracts;
using BLL.Documents;
using BLL.Servicio;
using DAL.Contracts;
using DAL.Repositorys;
using DAL.Tools;
using Data.Contracts;
using Data.Models;
using Domain.DTO;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Factura
{
    public class FacturaSevices : IFacturaService
    {
        private readonly IFacturaRepository _facturaRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<FacturaSevices> _logger;
        private readonly ServicioService _servicioService;

        public FacturaSevices(IFacturaRepository facturaRepository,
            IMapper mapper,
            ServicioService servicioService
            )
        {
            _facturaRepository = facturaRepository;
            _mapper = mapper;
            _servicioService = servicioService;
        }

        public async Task<Domain.Models.Factura> CrearFactura(FacturaDto facturaDto)
        {
        
            decimal subtotal = facturaDto.Detalles.Sum(d => d.ValorUnitario * d.Cantidad);
            decimal iva = subtotal * 0.19m; // IVA 19% en Colombia
            decimal total = subtotal + iva;
            int consecutivo = await _facturaRepository.ObtenerConsecutivoAsync();
 
            string numeroFactura = $"FV{DateTime.Now.Year}-{consecutivo + 1:0000}";


            var detalles = facturaDto.Detalles.Select(dto => new FacturaDetalle
            {
                IdServicio = dto.IdServicio,
                Descripcion = dto.Descripcion,
                Cantidad = dto.Cantidad,
                ValorUnitario = dto.ValorUnitario,
                Iva =  (dto.ValorUnitario * dto.Cantidad) * 0.19m,
                Total = (dto.ValorUnitario * dto.Cantidad) + ((dto.ValorUnitario * dto.Cantidad) * 0.19m)
            }).ToList();

            var factura = new Domain.Models.Factura
            {
                NumeroFactura = numeroFactura,
                FechaEmision = DateTime.Now,
                idPaciente = facturaDto.IdPaciente,
                IdPsicologo = facturaDto.IdPsicologo,
                Subtotal = subtotal,
                Iva = iva,
                Total = total,
                Estado = EstadoFactura.Generada,
                FacturaDetalle = detalles
            };
      

            var facturado = await _facturaRepository.CrearFacturaAsync(factura); 

            // 4. Enviar a la DIAN 
 
            return facturado;
        } 

        public async Task<PagedResult<ReportFacturaDTO>> GetFacturas(int page = 0, int pageSize = 10)
        {
            return  await _facturaRepository.GetFacturasPaginado(page, pageSize);
        }

        public async Task<PagedResult<ReportFacturaDTO>> GetFacturasbyClient(int Idpaciente, int page, int pageSize)
        {
            return await _facturaRepository.GetFacturasbyClient(Idpaciente, page, pageSize);
        }

        public async Task<Domain.Models.Factura> GetFacturasbyId(int IdFactura)
        {
            return await _facturaRepository.GetFacturasbyId(IdFactura);
        }

        public async Task<byte[]> GenerarFacturaPdf(int IdFactura, string wwwRootPath)
        {
            var factura = await GetFacturasbyId(IdFactura);
            var document = new FacturaDocument(factura, wwwRootPath);


            return document.GeneratePdf();
        }
    }
}
