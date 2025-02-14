using API.Models;
using Data.Models;
using Data.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositorys
{
    public class UsuarioRepository : Repository<User>
    {
        public UsuarioRepository(DbmindCareContext context, ILogger<Repository<User>> logger) : base(context, logger)
        {
        }

    }
}
