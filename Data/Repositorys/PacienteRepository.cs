using API.Models;
using Data.Contracts;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositorys
{
    public class PacienteRepository : Repository<Paciente>,  IPacienteRepository
    {
        public readonly DbmindCareContext context;

        public PacienteRepository(DbmindCareContext context, ILogger<Repository<Paciente>> logger) : base(context, logger)
        {
            this.context = context;
        }

        public Task<Boolean> ExistPaciente(string email)
        {
            var paciente =  context.DatosPersonales.FirstOrDefaultAsync(x => x.Email == email);

            if (paciente.Result == null)
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }
         
    }
}
