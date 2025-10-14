using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface IPagosRepository
    {
        Task<IEnumerable<Pagos>> GetPagosPorPsicologoAsync(int psicologoId, DateTime? fechaInicio, DateTime? fechaFin);
        Task<decimal> GetTotalPagadoPorPsicologoAsync(int psicologoId);
        Task<bool> ExisteFacturaAsync(int facturaId);
        Task<bool> ExistePsicologoAsync(int psicologoId);
        Task AddAsync(Pagos entity);
    }
}
