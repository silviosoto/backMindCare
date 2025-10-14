using API.Models;
using DAL.Contracts; 
using Data.Repository; 
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DAL.Repositorys
{
    public class ConceptoPsicologicoRepository : Repository<ConceptoPsicologico>, IConceptoPsicologicoRepository
    {
        public readonly DbmindCareContext context;
        public ConceptoPsicologicoRepository(DbmindCareContext context, ILogger<Repository<ConceptoPsicologico>> logger) : base(context, logger)
        {
            this.context = context;
        }

        public async Task<ConceptoPsicologico> ActualizarAsync(ConceptoPsicologico conceptoPsicologico)
        {
            var exist = GetByIdAsync(conceptoPsicologico.Id);
            if (exist != null)
            {
                await UpdateAsync(conceptoPsicologico);
            }

            return null;
        }

        public async Task CrearAsync(ConceptoPsicologico conceptoPsicologico)
        {
            await AddAsync(conceptoPsicologico);
        }

        public async Task<ConceptoPsicologico?> GetByHistoriaClinica(int idHistoriaClinica)
        {
            return await _context.ConceptoPsicologico.FirstOrDefaultAsync(x => x.IdHistoriaClinica == idHistoriaClinica);
        }

        public async Task<ConceptoPsicologico> GetById(int id)
        {
            return await GetByIdAsync(id);
        }
    }
}
