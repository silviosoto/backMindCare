using API.Models;
using DAL.Contracts;
using Data.Models;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositorys
{
    public class UsuarioRepository : Repository<User>, IUser
    {
        public readonly DbmindCareContext context;
        public UsuarioRepository(DbmindCareContext context, ILogger<Repository<User>> logger) : base(context, logger)
        {
            this.context = context;
        }

        public async Task<User> GetUserbyUserNameAsync(string username)
        {
             
            var usuario = await _context.Users
            .Include(u => u.IdDatosPersonalesNavigation)
            .Where(x => x.Username ==  username)
            .FirstOrDefaultAsync();

            return usuario;
        }

    }
}
