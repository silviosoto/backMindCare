using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositorys;
using Microsoft.Extensions.Logging;
using AutoMapper; 
using Domain.Models;
using Domain.DTO;
using API.Models;
using Data.Models;
using Data.Contracts;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using DAL.Tools;

namespace BLL.HobbiesBLL
{
    public class CitasServices
    {
        private readonly CitaRepository _citaRepopsitory;
        private readonly IMapper _mapper;
        private readonly SalaSevices salaSevices;

        public CitasServices(CitaRepository citaRepopsitory,
            IMapper mapper,
            SalaSevices salaSevices)
        {
            _citaRepopsitory = citaRepopsitory;
            _mapper = mapper;
            this.salaSevices = salaSevices;
        }

        public async Task<List<CitaDTO>>? GetAppointmentsAvailableByPsicologoAndDate(int idPsicologo, DateTime fecha)
        {
            var agenda = await _citaRepopsitory.GetAppointmentsAvailable(idPsicologo, fecha);
            return agenda;
        }

        public async Task<Cita> ApartarCita(CitaCreateDTO citaCreateDTO)
        {
            try
            {              
                Cita cita = _mapper.Map<Cita>(citaCreateDTO);
                cita.FechaCreacion = DateTime.Now;
                cita.Idterapia = 5;
                await _citaRepopsitory.AddAsync(cita);

                return cita;
            }
            catch (Exception e)
            {
                throw new BLLException(e.Message, e);
            }
        }

        public async Task<Cita> GetAppointment(int id)
        {
            try
            {
                return await _citaRepopsitory.GetByIdAsync(id);

            }
            catch (Exception e)
            {
                throw new BLLException(e.Message, e);
            }
        }

        public async Task<PagedResult<CitaDetalleDTO>> GetAppointmentByPatient(int idPaciente, int page, int pageSize)
        {
            try
            {
                return await _citaRepopsitory.GetAppointmentByPatient(idPaciente, page, pageSize);
            }
            catch (Exception e)
            {
                throw new BLLException(e.Message, e);
            }
        }

        public async Task<Boolean> CancelAppointment( int idCita )
        {
            try
            {
                return await _citaRepopsitory.CancelAppointment(idCita);
            }
            catch (Exception e) {
                throw new BLLException(e.Message, e);
            }

        }

        public async Task<Boolean> ConfirmAppointment(int idCita)
        {
            try
            {
                return await _citaRepopsitory.ConfirmAppointment(idCita);
            }
            catch (Exception e)
            {
                throw new BLLException(e.Message, e);
            }

        }

        public async Task<Boolean> Pagado(int idCita)
        {
            try
            {
                return await _citaRepopsitory.ConfirmPago(idCita);
            }
            catch (Exception e)
            {
                throw new BLLException(e.Message, e);
            }

        }
    }
}
