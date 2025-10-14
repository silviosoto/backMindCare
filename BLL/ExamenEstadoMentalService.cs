
using AutoMapper; 
using BLL.Contracts;
using BLL.DTOs;
using DAL.Contracts; 
using Domain.Models;
using Microsoft.Extensions.Logging;

namespace BLL
{
    public class ExamenEstadoMentalService : IExamenEstadoMentalService
    {
        private readonly IExamenEstadoMentalRepository _examenEstadoMentalRepository;
        private readonly IHistoriaclinicaRepository _historiaclinicaRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ExamenEstadoMental> _logger; 

        public ExamenEstadoMentalService(
            IExamenEstadoMentalRepository examenEstadoMentalRepository,
            IMapper mapper,
            IHistoriaclinicaRepository historiaclinicaRepository
            )
        {
            _examenEstadoMentalRepository = examenEstadoMentalRepository;
            _historiaclinicaRepository = historiaclinicaRepository;
            _mapper = mapper;
        }
         
        public async Task Actualizar(int Id, ExamenEstadoMentalDTO examenEstadoMentalDTO)
        {
            try
            {
                var existe = await _historiaclinicaRepository.GetById(examenEstadoMentalDTO.IdHistoriaClinica);
                if (existe == null)
                {
                    throw new Exception("No existe la historia clinica");
                }

                var signosFisicos = await _examenEstadoMentalRepository.GetById(Id);

                if (signosFisicos == null) { throw new Exception("No existe los signos fisicos"); }

                _mapper.Map(examenEstadoMentalDTO, signosFisicos);
                signosFisicos.FechaActualizacion = DateTime.Now;
                
                await _examenEstadoMentalRepository.ActualizarAsync(signosFisicos);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar Examen estado mental");
                throw;
            }
        }

        public async Task Crear(ExamenEstadoMentalDTO examenEstadoMentalDTO)
        {
            try
            {
                var existe = await _historiaclinicaRepository.GetById(examenEstadoMentalDTO.IdHistoriaClinica);
                if (existe == null)
                {
                    throw new Exception("No existe la historia clinica");
                }

                ExamenEstadoMental examen = _mapper.Map<ExamenEstadoMental>(examenEstadoMentalDTO);
                examen.FechaCreacion = DateTime.Now;
                examen.IdUsuarioCreacion = examenEstadoMentalDTO.IdUsuario;
                
                await _examenEstadoMentalRepository.CrearAsync(examen);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error al crear Examen estado mental");
                throw;
            }
        }

        public async Task<ExamenEstadoMental> GetByHistoriaClinica(int idHistoriaClinica)
        {
            return await _examenEstadoMentalRepository.GetByHistoriaClinica(idHistoriaClinica);
        }
    }
 
}
