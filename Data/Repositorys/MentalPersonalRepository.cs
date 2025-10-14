using API.Models;
using DAL.Contracts; 
using Data.Repository; 
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DAL.Repositorys
{
    public class MentalPersonalRepository : Repository<MentalPersonal>, IMentalPersonalRepository
    {
        public readonly DbmindCareContext context;
        public MentalPersonalRepository(DbmindCareContext context, ILogger<Repository<MentalPersonal>> logger) : base(context, logger)
        {
            this.context = context;
        }

        public async Task<MentalPersonal> ActualizarAsync(MentalPersonal mentalPersonal)
        {
            var exist = GetByIdAsync(mentalPersonal.Id);
            if (exist != null)
            {
                await UpdateAsync(mentalPersonal);
            }

            return null;
        }

        public async Task CrearAsync(MentalPersonal mentalPersonal)
        {
            await AddAsync(mentalPersonal);
        }

        public async Task<MentalPersonal?> GetByHistoriaClinica(int idHistoriaClinica)
        {
            return await _context.MentalPersonal.FirstOrDefaultAsync(x => x.IdHistoriaClinica == idHistoriaClinica);
        }

        public async Task<MentalPersonal> GetById(int id)
        {
            return await GetByIdAsync(id);
        }
    }
}
