using API.Models;
using DAL.Contracts;
using DAL.Tools;
using Data.Models;
using Data.Repository;
using Domain.DTO;
using Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DAL.Repositorys
{
    public class TerapiaRepository : Repository<Terapia>, ITerapiaRepository
    {
        public readonly DbmindCareContext context;
        public TerapiaRepository(DbmindCareContext context, ILogger<Repository<Terapia>> logger) : base(context, logger)
        {
            this.context = context;
        }
 
        public async Task<Terapia> CrearAsync(Terapia terapia)
        {
            await AddAsync(terapia);
            return terapia;
        }
    }
}
