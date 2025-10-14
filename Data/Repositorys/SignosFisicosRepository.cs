using API.Models;
using DAL.Contracts; 
using Data.Repository; 
using Domain.Models; 
using Microsoft.Extensions.Logging;

namespace DAL.Repositorys
{
    public class SignosFisicosRepository : Repository<SignosFisicos>, ISignosFisicosRepository
    {
        public readonly DbmindCareContext context;
        public SignosFisicosRepository(DbmindCareContext context, ILogger<Repository<SignosFisicos>> logger) : base(context, logger)
        {
            this.context = context;
        }

        public async Task<SignosFisicos> ActualizarAsync(SignosFisicos signosFisicos)
        {
            var exist = GetByIdAsync(signosFisicos.Id);
            if (exist != null)
            {
                await UpdateAsync(signosFisicos);
            }

            return null;
        }

        public async Task CrearAsync(SignosFisicos signosFisicos)
        {
            await AddAsync(signosFisicos);
        }

        public async Task<SignosFisicos> GetById(int id)
        {
            return await GetByIdAsync(id);
        }
    }
}
