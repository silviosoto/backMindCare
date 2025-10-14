using API.Models;
using AutoMapper; 
using BLL.Contracts;
using BLL.Documents;
using BLL.Servicio;
using DAL.Contracts;
using DAL.Tools;
using Domain.DTO;
using Domain.Models;
using Microsoft.Extensions.Logging;
using QuestPDF.Fluent;


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
            try
            {
                decimal subtotal = facturaDto.Detalles.Sum(d => d.ValorUnitario * d.Cantidad);
                decimal iva = subtotal * 0.19m; // IVA 19% en Colombia
                decimal total = subtotal + iva;
                int consecutivo = await _facturaRepository.ObtenerConsecutivoAsync();

                string numeroFactura = $"FV{DateTime.Now.Year}-{consecutivo + 1:0000}";

                int idServicio = facturaDto.Detalles.FirstOrDefault().IdServicio;
                var servicio = await _servicioService.GetServicioById(idServicio);

                if (servicio == null)
                {
                    throw new Exception("Servicio no encontrado");
                }

                var detalles = facturaDto.Detalles.Select(dto => new FacturaDetalle
                {                    
                    IdServicio = dto.IdServicio,
                    IdTerapia = dto.IdTerapia,
                    Descripcion = servicio.Nombre,
                    Cantidad = dto.Cantidad,
                    ValorUnitario = dto.ValorUnitario,
                    Iva = (dto.ValorUnitario * dto.Cantidad) * 0.19m,
                    Total = (dto.ValorUnitario * dto.Cantidad) + ((dto.ValorUnitario * dto.Cantidad) * 0.19m)
                }).ToList();
                
                var factura = new Domain.Models.Factura
                {
                    NumeroFactura = numeroFactura,
                    FechaEmision = DateTime.Now,
                    idPaciente = facturaDto.IdPaciente,
                    Subtotal = subtotal,
                    Iva = iva,
                    Total = total,
                    Estado = EstadoFactura.Generada,
                    FacturaDetalle = detalles
                };


                var facturado = await _facturaRepository.CrearFacturaAsync(factura);


                return facturado;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error al crear la factura");
                throw;
            }
          
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

        public async Task<PagedResult<paymethpsychologistDTO>> PaymethPsychologist(int idPsicologo, DateTime Fechainicio,
            DateTime Fechafin, int pageNumber = 0, int pageSize = 10)
        {
            return await _facturaRepository.GetPaymethPsychologist(
              idPsicologo,
              Fechainicio,
              Fechafin,
              pageNumber,
              pageSize); 
        }

        public async Task<bool> estafacturadaLaTerapia(int idterapia)
        {
            return await _facturaRepository.IsTerapiaFacturada(idterapia);
        }
    }
}
