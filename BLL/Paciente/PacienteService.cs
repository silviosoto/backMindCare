using API.Models;
using AutoMapper;
using DAL.Contracts;
using DAL.Repositorys;
using Data.Contracts;
using Data.Models;
using Domain.DTO;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicio
{
    public class PacienteService
    {
        private readonly PacienteRepository _pacienteRepository;
        private readonly IMapper _mapper;

        public PacienteService(PacienteRepository pacienteRepository, IMapper mapper)
        {
            _pacienteRepository = pacienteRepository;
            _mapper = mapper;
        }

        public async Task<Paciente> Insert(PacienteDTO pacienteDTO)
        {
            try
            {
                bool exists = await _pacienteRepository.ExistPaciente(pacienteDTO.datosPersonale.Email);

                if (exists)
                {
                    throw new Exception("El paciente ya está registrado.");
                }

                //pacienteDTO.datosPersonale.User.idPerfil = 2;
                Paciente paciente = _mapper.Map<Paciente>(pacienteDTO);
                paciente.DatosPersonale.User.idPerfil = 2;
                paciente.FechaCreacion = DateTime.Now; 
                await _pacienteRepository.AddAsync(paciente);
                return paciente;
            }
            catch (Exception e)
            {
                throw new BLLException(e.Message, e);
            }
        }

        public async Task<bool> saveImage(int id, string image)
        {
            try
            {
                var paciente = await GetPaciente(id);
                if (paciente == null) {
                    throw new Exception("El paciente no está registrado.");
                }

                paciente.DatosPersonale.ImagePerfil = image;
                paciente.FechaActualizacion = DateTime.Now;
                
                //_mapper.Map<Paciente>(paciente);
                _pacienteRepository.context.Entry(paciente.DatosPersonale).State = EntityState.Modified;
                await _pacienteRepository.UpdateAsync(paciente);

                return true;
            }
            catch (Exception e)
            {
                throw new BLLException(e.Message, e);
            }
        }

        public async Task<bool> Update( int id, PacienteUpdateDTO pacienteUpdateDTO)
        {
            try
            {
                var paciente = await _pacienteRepository.GetByIdAsync(id);
                if (paciente == null) { return false; }

                _mapper.Map(pacienteUpdateDTO, paciente);
                paciente.FechaCreacion = DateTime.Now;
                await _pacienteRepository.UpdateAsync(paciente);

                return true;
            }
            catch (Exception e)
            {
                throw new BLLException(e.Message, e);
            }
        }

        public async Task<Paciente?> GetPacientByUser(int id) {

            try
            {

                return await _pacienteRepository.context.Pacientes
                     .Include(p => p.DatosPersonale)
                     .AsNoTracking()
                     .FirstOrDefaultAsync(w => w.DatosPersonale.User.Id == id);
               
            }
            catch (Exception e)
            {
                throw new BLLException(e.Message, e);
            }
        }

        public async Task<Paciente?> GetPaciente(int id)
        {
            try
            {

                return await _pacienteRepository.context.Pacientes
                     .Include(p => p.DatosPersonale)
                     .AsNoTracking()
                     .FirstOrDefaultAsync(w => w.Id == id);

            }
            catch (Exception e)
            {
                throw new BLLException(e.Message, e);
            }
        }

    }
}
