using API.Models;
using Data.Contracts;
using Data.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositorys
{
    public class ServicioRepository : Repository<Servicio>, IServicioRepository
    {
        public readonly DbmindCareContext context;

        public ServicioRepository(DbmindCareContext context, ILogger<Repository<Servicio>> logger) : base(context, logger)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Servicio>> GetAllServicio()
        {
            var servicios = await GetAllAsync();
            return servicios;
        }

        public async Task<Servicio> GetServicioById(int id)
        {
            var servicio = await GetByIdAsync(id);
            return servicio;
        }

        public async Task<IEnumerable<Servicio>> SearchCoincenceServiceName(string nombre)
        {
            Expression<Func<Servicio, bool>> filter = c => c.Nombre.Contains(nombre);
            var Servicio = await FindAsync(filter);
           
            return Servicio.ToList();
        }

     
    }
}
