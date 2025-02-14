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

namespace BLL.HobbiesBLL
{
    public class AgendaSevices
    {
        private readonly AgendaRepository _agendaRepopsitory;
        private readonly IMapper _mapper;

        public AgendaSevices(AgendaRepository agendaRepopsitory, IMapper mapper)
        {
            _agendaRepopsitory = agendaRepopsitory;
            _mapper = mapper;
        }

        public async Task<Agenda> Insert(AgendaDTO agendaDTO)
        {
            try
            {
                int idPsicologo = await _agendaRepopsitory.GetPsicologoByUser(agendaDTO.IdUser);
                //validar si ya tiene ese horario ocupado 
                bool disponible = _agendaRepopsitory.EsHorarioDisponible(
                        agendaDTO.HoraInicio, agendaDTO.HoraFin, idPsicologo, agendaDTO.anio, agendaDTO.mes, agendaDTO.DiaSemana);
                if (!disponible)
                {
                    throw new BLLException("Horario no disponible");
                }
                
                Agenda agenda = _mapper.Map<Agenda>(agendaDTO);
                agenda.Idpsicologo = idPsicologo;
                agenda.FechaCreacion = DateTime.Now;
                agenda.Estado = true;
                await _agendaRepopsitory.AddAsync(agenda);

                return agenda;
            }
            catch (Exception e)
            {
                throw new BLLException(e.Message, e);
            }
        }

        public async Task<List<AgendaResponseDTO>> GetAgendaByPsicologo(AgendaByPsicologoDTO agendaByPsicologoDTO)
        {
            try
            {

                return await _agendaRepopsitory.GetAgendaByPsicologo(agendaByPsicologoDTO.IdUser,
                    agendaByPsicologoDTO.DiaSemana, agendaByPsicologoDTO.mes, agendaByPsicologoDTO.anio);

            }
            catch (Exception e)
            {
                throw new BLLException(e.Message, e);
            }
        }

        public async Task SoftDeleteAsync(int Id)
        {
            await _agendaRepopsitory.SoftDeleteAsync(Id);
        }

        public async Task<Agenda> GetHobbieById(int id)
        {
            var agenda = await _agendaRepopsitory.GetByIdAsync(id);
            return agenda;
        }
    }
}
