using API.Models;
using DAL.Contracts;
using Data.Contracts;
using Data.Models;
using Data.Repository;
using Domain.DTO;
using Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositorys
{
    public class CitaRepository : Repository<Cita>, ICita
    {
        public readonly DbmindCareContext context;
        public CitaRepository(DbmindCareContext context, ILogger<Repository<Cita>> logger) : base(context, logger)
        {
            this.context = context;
        }

        public async Task<List<CitaDTO>>? GetAppointmentsAvailable(int idPsicologo, DateTime date)
        {
            var citas = await context.Database.SqlQueryRaw<CitaDTO>(
                          "EXEC GetAvailableAppointments @idPsicologo,@Fecha ",
                          new SqlParameter("@idPsicologo", idPsicologo),
                          new SqlParameter("@Fecha", date)
                          ).ToListAsync();

            return citas;
        }


    }
}
