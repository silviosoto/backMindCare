using API.Models;
using DAL.Contracts; 
using Data.Repository; 
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DAL.Repositorys
{
    public class ExamenEstadoMentalRepository : Repository<ExamenEstadoMental>, IExamenEstadoMentalRepository
    {
        public readonly DbmindCareContext context;
        public ExamenEstadoMentalRepository(DbmindCareContext context, ILogger<Repository<ExamenEstadoMental>> logger) : base(context, logger)
        {
            this.context = context;
        }

        public async Task<ExamenEstadoMental> ActualizarAsync(ExamenEstadoMental examenEstadoMental)
        {
            var exist = GetByIdAsync(examenEstadoMental.Id);
            if (exist != null)
            {
                await UpdateAsync(examenEstadoMental);
            }

            return null;
        }

        public async Task CrearAsync(ExamenEstadoMental examenEstadoMental)
        {
            await AddAsync(examenEstadoMental);
        }

        public async Task<ExamenEstadoMental?> GetByHistoriaClinica(int idHistoriaClinica)
        {
            return await _context.ExamenEstadoMental.FirstOrDefaultAsync(x => x.IdHistoriaClinica == idHistoriaClinica);
        }

        public async Task<ExamenEstadoMental> GetById(int id)
        {
            return await GetByIdAsync(id);
        }
    }
}
