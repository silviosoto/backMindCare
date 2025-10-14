using BLL.DTOs;
using DAL.Tools;
using Domain.DTO;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BLL.Contracts
{
    public interface IPagoService
    {
        Task<Pagos> RegistrarPagoAsync(PagoDto pagoDto);
        //Task<IEnumerable<Pagos>> ObtenerPagosPorPsicologoAsync(Guid psicologoId, DateTime? fechaInicio, DateTime? fechaFin);
        //Task<decimal> ObtenerTotalPagadoPorPsicologoAsync(Guid psicologoId);
    }
}
