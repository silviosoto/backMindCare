using API.Models;
using Azure;
using DAL.Contracts;
using DAL.Tools;
using Data.Models;
using Data.Repository;
using Domain.DTO;
using Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositorys
{
    public class PagosRepository : Repository<Pagos>, IPagosRepository
    {
        public readonly DbmindCareContext context;
        public PagosRepository(DbmindCareContext context,
                ILogger<Repository<Pagos>> logger) : base(context, logger)
        {
            this.context = context;
        }

        public async Task<Pagos> GetByIdAsync(int id)
        {
        return await _context.Pagos
            .Include(p => p.Psicologo)
            .Include(p => p.Factura)
             
            .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Pagos>> GetAllAsync()
        {
            return await _context.Pagos
                .Include(p => p.Psicologo)
                .Include(p => p.Factura)
                .ToListAsync();
        }

        public async Task AddAsync(Pagos entity)
        {
            await _context.Pagos.AddAsync(entity);
        }

        public void Update(Pagos entity)
        {
            _context.Pagos.Update(entity);
        }

        public void Delete(Pagos entity)
        {
            _context.Pagos.Remove(entity);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Pagos>> GetPagosPorPsicologoAsync(int psicologoId, DateTime? fechaInicio, DateTime? fechaFin)
        {
            var query = _context.Pagos
                .Include(p => p.Factura)
                 
                .Where(p => p.PsicologoId == psicologoId);

            if (fechaInicio.HasValue)
                query = query.Where(p => p.FechaPago >= fechaInicio.Value);

            if (fechaFin.HasValue)
                query = query.Where(p => p.FechaPago <= fechaFin.Value);

            return await query.OrderByDescending(p => p.FechaPago).ToListAsync();
        }

        public async Task<decimal> GetTotalPagadoPorPsicologoAsync(int psicologoId)
        {
            return await _context.Pagos
                .Where(p => p.PsicologoId == psicologoId && p.Estado == "PAGADO")
                .SumAsync(p => p.Monto);
        }

        public async Task<bool> ExisteFacturaAsync(int facturaId)
        {
            return await _context.Facturas.AnyAsync(f => f.Id == facturaId);
        }

        public async Task<bool> ExistePsicologoAsync(int psicologoId)
        {
            return await _context.Psicologos.AnyAsync(p => p.Id == psicologoId);
        }
    }
}
