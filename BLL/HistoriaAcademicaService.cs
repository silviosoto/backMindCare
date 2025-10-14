
using AutoMapper; 
using BLL.Contracts;
using BLL.DTOs;
using DAL.Contracts; 
using Domain.Models;
using Microsoft.Extensions.Logging;

namespace BLL
{
    public class HistoriaAcademicaService : IHistoriaAcademicaService
    {
        private readonly IHistoriaAcademicaRepository _historiaAcademicaRepository;
        private readonly IHistoriaclinicaRepository _historiaclinicaRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<MentalPersonal> _logger; 

        public HistoriaAcademicaService(
            IHistoriaAcademicaRepository historiaAcademicaRepository,
            IMapper mapper,
            IHistoriaclinicaRepository historiaclinicaRepository
            )
        {
            _historiaAcademicaRepository = historiaAcademicaRepository;
            _historiaclinicaRepository = historiaclinicaRepository;
            _mapper = mapper;
        }
         
        public async Task Actualizar(int Id, HistoriaAcademicaDTO historiaAcademicaDTO)
        {
            try
            {
                var existe = await _historiaclinicaRepository.GetById(historiaAcademicaDTO.IdHistoriaClinica);
                if (existe == null)
                {
                    throw new Exception("No existe la historia clinica");
                }

                var historiaAcademica = await _historiaAcademicaRepository.GetById(Id);

                if (historiaAcademica == null) { throw new Exception("No existe los Historia Academica"); }

                _mapper.Map(historiaAcademicaDTO, historiaAcademica);
                historiaAcademica.FechaActualizacion = DateTime.Now;
                
                await _historiaAcademicaRepository.ActualizarAsync(historiaAcademica);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar Historia Academica");
                throw;
            }
        }

        public async Task Crear(HistoriaAcademicaDTO historiaAcademicaDTO)
        {
            try
            {
                var existe = await _historiaclinicaRepository.GetById(historiaAcademicaDTO.IdHistoriaClinica);
                if (existe == null)
                {
                    throw new Exception("No existe la historia clinica");
                }

                HistoriaAcademica historiaAcademica = _mapper.Map<HistoriaAcademica>(historiaAcademicaDTO);
                historiaAcademica.FechaCreacion = DateTime.Now;
                historiaAcademica.IdUsuarioCreacion = historiaAcademicaDTO.IdUsuario;
                
                await _historiaAcademicaRepository.CrearAsync(historiaAcademica);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error al crear Historia Academica");
                throw;
            }
        }

        public async Task<HistoriaAcademica> GetByHistoriaClinica(int idHistoriaClinica)
        {
            return await _historiaAcademicaRepository.GetByHistoriaClinica(idHistoriaClinica);
        }
    }
 
}
