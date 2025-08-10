using API.Models;
using DAL.Contracts;
using DAL.Helper;
using DAL.Tool;
using DAL.Tools;
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
        public async Task<PagedResult<CitaDetalleDTO>>? GetAppointmentByPatient( int idPaciente, int page, int pageSize = 10)
        {
            page = (page == 0) ? 1 : page;

            var citas = context.Cita
                  .Include(x => x.psicologo)
                    .ThenInclude(r => r.IdDatosPersonalesNavigation)
                  .Include(x => x.sala)
                  .Include(x => x.servicio)
                  .Where(x => x.Idpaciente == idPaciente)
                  .OrderBy(x => x.Fecha)
                  .ThenBy(x => x.Hora);

            var totalRecords = await citas.CountAsync();
           

            var CitasPaginadas = await citas
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(s => new CitaDetalleDTO
                {
                    Id = s.Id,
                    Fecha = s.Fecha,
                    Hora = s.Hora,
                    Estado = s.Estado,
                    EstadoString = ToolDAL.ObtenerNombreEstado(s.Estado),
                    Nombre = s.psicologo.IdDatosPersonalesNavigation.Nombre,
                    Apellidos = s.psicologo.IdDatosPersonalesNavigation.Apellidos,
                    ImagePerfil = s.psicologo.IdDatosPersonalesNavigation.ImagePerfil,
                    MotivoConsulta = s.MotivoConsulta,
                    Url = s.sala.UrlHost,
                    Token = s.sala.TokenHost,
                    Servicio = s.servicio.Nombre
                })                   
                .ToListAsync();

            return new PagedResult<CitaDetalleDTO>
            {
                Items = CitasPaginadas,
                PageNumber = page,
                PageSize = pageSize,
                TotalRecords = totalRecords
            };
 
        }

        public async Task<Boolean> CancelAppointment(int id)
        {

            try
            {
                var entity = await context.Cita.FindAsync(id);
                if (entity == null)
                {
                    return false;
                }

                entity.Estado = EstadoCita.Cancelada;
                entity.FechaActualizacion = DateTime.Now;
                _context.Cita.Update(entity);

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Boolean> ConfirmAppointment(int id)
        {

            try
            {
                var entity = await context.Cita.FindAsync(id);
                if (entity == null)
                {
                    return false;
                }

                entity.Estado = EstadoCita.Confirmada;
                entity.FechaActualizacion = DateTime.Now;
                _context.Cita.Update(entity);

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Boolean> ConfirmPago(int id)
        {

            try
            {
                var entity = await context.Cita.FindAsync(id);
                if (entity == null)
                {
                    return false;
                }

                entity.pagado = true;
                entity.FechaActualizacion = DateTime.Now;
                _context.Cita.Update(entity);

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
