using API.Models;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IServicioRepository : IRepository<Servicio>
    {
        Task<IEnumerable<Servicio>> SearchCoincenceServiceName(string nombre);
        Task<IEnumerable<Servicio>> GetAllServicio();
        Task<API.Models.Servicio> GetServicioById(int id);
    }
}
