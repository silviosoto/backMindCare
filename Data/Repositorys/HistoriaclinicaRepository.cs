using API.Models;
using DAL.Contracts;
using DAL.Tools;
using Data.Repository;
using Domain.DTO;
using Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DAL.Repositorys
{
    public class HistoriaclinicaRepository : Repository<HistoriaClinica>, IHistoriaclinicaRepository
    {
        public readonly DbmindCareContext context;
        public HistoriaclinicaRepository(DbmindCareContext context, ILogger<Repository<HistoriaClinica>> logger) : base(context, logger)
        {
            this.context = context;
        }

        public async Task<HistoriaClinica> ActualizarAsync(HistoriaClinica historiaclinica)
        {
            var exist = GetByIdAsync(historiaclinica.Id);
            if (exist != null)
            {
                await UpdateAsync(historiaclinica);
            }

            return null;
        }

        public async Task CrearAsync(HistoriaClinica historiaClinica)
        {
            await AddAsync(historiaClinica);
        }

        public async Task<HistoriaClinica> GetById(int Id)
        {
            return await GetByIdAsync(Id);
        }

        public async Task<HistoriaClinica?> GetByPaciente(int paciente)
        {
             return await _context.HistoriaClinica
                .Include(h => h.Paciente)
                    .ThenInclude(p => p.DatosPersonale)            
                .FirstOrDefaultAsync(h => h.IdPaciente == paciente);
        }


         
    }
}
