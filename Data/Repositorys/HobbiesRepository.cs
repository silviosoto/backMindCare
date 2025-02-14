using API.Models;
using DAL.Contracts;
using Data.Contracts;
using Data.Models;
using Data.Repository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositorys
{
    public class HobbiesRepository : Repository<Hobbies>, IHobbies
    {
        public readonly DbmindCareContext context;
        public HobbiesRepository(DbmindCareContext context, ILogger<Repository<Hobbies>> logger) : base(context, logger)
        {
            this.context = context;
        }

        public async Task<int> GetDatosPersonales(int idUser)
        {
            int IdDatosPersonale = await context.Users.Where(x => x.Id == idUser)
                .Select(x => x.IdDatosPersonales)
                .FirstOrDefaultAsync();

            return IdDatosPersonale;
        }

        public async Task<List<Hobbies>> GetHobbiesByUser(int IdUser)
        {
            return await context.Hobbies.Where( x=> x.IdUser == IdUser && x.Estado == true)
                .AsNoTracking()
                .ToListAsync();

        }


    }
}
