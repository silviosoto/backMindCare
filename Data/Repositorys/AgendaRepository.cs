using API.Models;
using DAL.Contracts;
using Data.Contracts;
using Data.Models;
using Data.Repository;
using Domain.DTO;
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
    public class AgendaRepository : Repository<Agenda>, IAgenda
    {
        public readonly DbmindCareContext context;
        public AgendaRepository(DbmindCareContext context, ILogger<Repository<Agenda>> logger) : base(context, logger)
        {
            this.context = context;
        }

        public async Task<int> GetPsicologoByUser(int idUser)
        {
            int Iddatos_personales = await context.Users
            .Where(x => x.Id == idUser)
            .Select(u => u.IdDatosPersonales )
            .FirstOrDefaultAsync();

            int id_psicologo = await context.Psicologos
                .Where(x => x.IdDatosPersonales == Iddatos_personales)
                .Select(u => u.Id)
                .FirstOrDefaultAsync();

            return id_psicologo;
        }

        public async Task<List<AgendaResponseDTO>> GetAgendaByPsicologo(int IdUser, int DiaSemana, int mes, int anio)
        {

           int Idpsicologo = await  GetPsicologoByUser(IdUser);

               var list = await context.Agenda.Where(
                   x=> x.Idpsicologo == Idpsicologo
                && x.anio == anio
                && x.mes == mes
                && x.DiaSemana == DiaSemana
                && x.Estado == true 
                )
              .Select(ag => new AgendaResponseDTO
              {
                  Id = ag.Id,
                  idPsicologo = ag.Idpsicologo,
                  anio = ag.anio,
                  mes = ag.mes,
                  DiaSemana = ag.DiaSemana,
                  HoraInicio = ag.HoraInicio,
                  HoraFin = ag.HoraFin
              })
              .AsNoTracking()
              .OrderBy(o => o.DiaSemana )
              .ToListAsync();

            return list;
        }

        public bool EsHorarioDisponible(TimeSpan nuevaHoraInicio, 
                    TimeSpan nuevaHoraFin, 
                    int Idpsicologo, 
                    int anio,
                    int mes,
                    int DiaSemana) {

            return !_context.Agenda.Any(h =>
                h.Idpsicologo == Idpsicologo
                && h.anio == anio
                && h.mes == mes
                && h.DiaSemana == DiaSemana
                && h.Estado == true
                &&
                (nuevaHoraInicio >= h.HoraInicio && nuevaHoraInicio < h.HoraFin) || 
                (nuevaHoraFin > h.HoraInicio && nuevaHoraFin <= h.HoraFin) ||
                (nuevaHoraInicio <= h.HoraInicio && nuevaHoraFin >= h.HoraFin));
        }

    }
}
