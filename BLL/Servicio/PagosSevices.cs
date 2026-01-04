using API.Models;
using AutoMapper;
using BLL.Contracts;
using BLL.Documents;
using BLL.DTOs;
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

namespace BLL.Servicio
{
    public class PagosSevices : IPagoService
    {
        private readonly IPagosRepository _pagosRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<PagosSevices> _logger;
        private readonly IFacturaService _facturaService;
        private readonly PsicologoService _psicologoService; 
        public PagosSevices(
            IPagosRepository pagosRepository,
            IMapper mapper,
            IFacturaService facturaService,
            PsicologoService psicologoService

            )
        {
            _pagosRepository = pagosRepository;
            _mapper = mapper;
            _facturaService = facturaService;
            _psicologoService = psicologoService;
        }

        public async Task<Pagos> RegistrarPagoAsync(PagoDto pagoDto)
        {
            // Validaciones de negocio
            if (!ValidarPagoDto(pagoDto))
                throw new ArgumentException("Datos de pago inválidos");

            // Verificar existencia de entidades relacionadas
            var psicologoExiste = await _psicologoService.GetPsicologoById(pagoDto.PsicologoId) != null;
            var facturaExiste = await _facturaService.GetFacturasbyId(pagoDto.FacturaId) != null;

            if (!psicologoExiste || !facturaExiste)
                throw new KeyNotFoundException("Psicólogo o factura no encontrados");

            // Validar paquete si aplica
            //if (pagoDto.TipoPago == "PAQUETE")
            //{
            //    await ValidarPaqueteAsync(pagoDto.PaqueteId.Value, pagoDto.NumeroSesion.Value);
            //}

            var pago = new Pagos
            {
                PsicologoId = pagoDto.PsicologoId,
                FacturaId = pagoDto.FacturaId,
                TipoPago = pagoDto.TipoPago,
                PaqueteId = pagoDto.PaqueteId,
                NumeroSesion = pagoDto.NumeroSesion,
                Monto = pagoDto.Monto,
                FechaPago = DateTime.Now,
                Estado = "PAGADO"
            };

            await _pagosRepository.AddAsync(pago);
            

            return pago;
        }

        public async Task<IEnumerable<Pagos>> ObtenerPagosPorPsicologoAsync(int psicologoId, DateTime? fechaInicio, DateTime? fechaFin)
        {
            return await _pagosRepository.GetPagosPorPsicologoAsync(psicologoId, fechaInicio, fechaFin);
        }

        public async Task<decimal> ObtenerTotalPagadoPorPsicologoAsync(int psicologoId)
        {
            return await _pagosRepository.GetTotalPagadoPorPsicologoAsync(psicologoId);
        }

        private bool ValidarPagoDto(PagoDto pagoDto)
        {
            return pagoDto.PsicologoId != null &&
                   pagoDto.FacturaId != null &&
                   !string.IsNullOrEmpty(pagoDto.TipoPago) &&
                   pagoDto.Monto > 0 &&
                   (pagoDto.TipoPago != "PAQUETE" || (pagoDto.PaqueteId.HasValue && pagoDto.NumeroSesion.HasValue));
        }

        //public Task<IEnumerable<Pagos>> ObtenerPagosPorPsicologoAsync(Guid psicologoId, DateTime? fechaInicio, DateTime? fechaFin)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<decimal> ObtenerTotalPagadoPorPsicologoAsync(Guid psicologoId)
        //{
        //    throw new NotImplementedException();
        //}

        //private async Task ValidarPaqueteAsync(Guid paqueteId, int numeroSesion)
        //{
        //    var paquete = await _unitOfWork.Paquetes.GetByIdAsync(paqueteId);
        //    if (paquete == null)
        //        throw new KeyNotFoundException("Paquete no encontrado");

        //    if (numeroSesion < 1 || numeroSesion > paquete.NumeroSesiones)
        //        throw new ArgumentException("Número de sesión inválido para este paquete");
        //}
    }
}
