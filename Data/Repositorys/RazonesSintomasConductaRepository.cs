using API.Models;
using DAL.Contracts; 
using Data.Repository; 
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DAL.Repositorys
{
    public class RazonesSintomasConductaRepository : Repository<RazonesSintomasConducta>, IRazonesSintomasConductaRepository
    {
        public readonly DbmindCareContext context;
        public RazonesSintomasConductaRepository(DbmindCareContext context, ILogger<Repository<RazonesSintomasConducta>> logger) : base(context, logger)
        {
            this.context = context;
        }

        public async Task<RazonesSintomasConducta> ActualizarAsync(RazonesSintomasConducta razonesSintomasConducta)
        {
            var exist = GetByIdAsync(razonesSintomasConducta.Id);
            if (exist != null)
            {
                await UpdateAsync(razonesSintomasConducta);
            }

            return null;
        }

        public async Task CrearAsync(RazonesSintomasConducta razonesSintomasConducta)
        {
            await AddAsync(razonesSintomasConducta);
        }

        public async Task<RazonesSintomasConducta?> GetByHistoriaClinica(int idHistoriaClinica)
        {
            return await _context.RazonesSintomasConducta.FirstOrDefaultAsync(x => x.IdHistoriaClinica == idHistoriaClinica);
        }

        public async Task<RazonesSintomasConducta> GetById(int id)
        {
            return await GetByIdAsync(id);
        }
    }
}
