using API.Models;
using DAL.Contracts; 
using Data.Repository; 
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DAL.Repositorys
{
    public class DesarrolloPsicosexualRepository : Repository<DesarrolloPsicosexual>, IDesarrolloPsicosexualRepository
    {
        public readonly DbmindCareContext context;
        public DesarrolloPsicosexualRepository(DbmindCareContext context, ILogger<Repository<DesarrolloPsicosexual>> logger) : base(context, logger)
        {
            this.context = context;
        }

        public async Task<DesarrolloPsicosexual> ActualizarAsync(DesarrolloPsicosexual desarrolloPsicosexual)
        {
            var exist = GetByIdAsync(desarrolloPsicosexual.Id);
            if (exist != null)
            {
                await UpdateAsync(desarrolloPsicosexual);
            }

            return null;
        }

        public async Task CrearAsync(DesarrolloPsicosexual desarrolloPsicosexual)
        {
            await AddAsync(desarrolloPsicosexual);
        }

        public async Task<DesarrolloPsicosexual?> GetByHistoriaClinica(int idHistoriaClinica)
        {
            return await _context.DesarrolloPsicosexual.FirstOrDefaultAsync(x => x.IdHistoriaClinica == idHistoriaClinica);
        }

        public async Task<DesarrolloPsicosexual> GetById(int id)
        {
            return await GetByIdAsync(id);
        }
    }
}
