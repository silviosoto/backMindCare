using API.Models;
using DAL.Contracts; 
using Data.Repository; 
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DAL.Repositorys
{
    public class HistoriaAcademicaRepository : Repository<HistoriaAcademica>, IHistoriaAcademicaRepository
    {
        public readonly DbmindCareContext context;
        public HistoriaAcademicaRepository(DbmindCareContext context, ILogger<Repository<HistoriaAcademica>> logger) : base(context, logger)
        {
            this.context = context;
        }

        public async Task<HistoriaAcademica> ActualizarAsync(HistoriaAcademica historiaAcademica)
        {
            var exist = GetByIdAsync(historiaAcademica.Id);
            if (exist != null)
            {
                await UpdateAsync(historiaAcademica);
            }

            return null;
        }

        public async Task CrearAsync(HistoriaAcademica historiaAcademica)
        {
            await AddAsync(historiaAcademica);
        }

        public async Task<HistoriaAcademica?> GetByHistoriaClinica(int idHistoriaClinica)
        {
            return await _context.HistoriaAcademica.FirstOrDefaultAsync(x => x.IdHistoriaClinica == idHistoriaClinica);
        }

        public async Task<HistoriaAcademica> GetById(int id)
        {
            return await GetByIdAsync(id);
        }
    }
}
