
using AutoMapper;
using BLL.Contracts;
using BLL.DTOs;
using DAL.Contracts;
using Domain.Models;
using Microsoft.Extensions.Logging;

namespace BLL.Servicio
{
    public class DesarrolloPsicosexualService : IDesarrolloPsicosexualService
    {
        private readonly IDesarrolloPsicosexualRepository _desarrolloPsicosexualRepository;
        private readonly IHistoriaclinicaRepository _historiaclinicaRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<MentalPersonal> _logger; 

        public DesarrolloPsicosexualService(
            IDesarrolloPsicosexualRepository desarrolloPsicosexualRepository,
            IMapper mapper,
            IHistoriaclinicaRepository historiaclinicaRepository
            )
        {
            _desarrolloPsicosexualRepository = desarrolloPsicosexualRepository;
            _historiaclinicaRepository = historiaclinicaRepository;
            _mapper = mapper;
        }
         
        public async Task Actualizar(int Id, DesarrolloPsicosexualDTO desarrolloPsicosexualDTO)
        {
            try
            {
                var existe = await _historiaclinicaRepository.GetById(desarrolloPsicosexualDTO.IdHistoriaClinica);
                if (existe == null)
                {
                    throw new Exception("No existe la historia clinica");
                }

                var signosFisicos = await _desarrolloPsicosexualRepository.GetById(Id);

                if (signosFisicos == null) { throw new Exception("No existe los signos fisicos"); }

                _mapper.Map(desarrolloPsicosexualDTO, signosFisicos);
                signosFisicos.FechaActualizacion = DateTime.Now;
                
                await _desarrolloPsicosexualRepository.ActualizarAsync(signosFisicos);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar Desarrollo Psicos");
                throw;
            }
        }

        public async Task Crear(DesarrolloPsicosexualDTO desarrolloPsicosexualDTO)
        {
            try
            {
                var existe = await _historiaclinicaRepository.GetById(desarrolloPsicosexualDTO.IdHistoriaClinica);
                if (existe == null)
                {
                    throw new Exception("No existe la historia clinica");
                }

                DesarrolloPsicosexual desarrolloPsicosexual = _mapper.Map<DesarrolloPsicosexual>(desarrolloPsicosexualDTO);
                desarrolloPsicosexual.FechaCreacion = DateTime.Now;
                desarrolloPsicosexual.IdUsuarioCreacion = desarrolloPsicosexualDTO.IdUsuario;
                
                await _desarrolloPsicosexualRepository.CrearAsync(desarrolloPsicosexual);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error al crear Desarrollo Psicos");
                throw;
            }
        }

        public async Task<DesarrolloPsicosexual> GetByHistoriaClinica(int idHistoriaClinica)
        {
            return await _desarrolloPsicosexualRepository.GetByHistoriaClinica(idHistoriaClinica);
        }
    }
 
}
