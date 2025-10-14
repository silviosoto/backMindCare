
using AutoMapper; 
using BLL.Contracts;
using BLL.DTOs;
using DAL.Contracts; 
using Domain.Models;
using Microsoft.Extensions.Logging;

namespace BLL
{
    public class MentalPersonalService : IMentalPersonalService
    {
        private readonly IMentalPersonalRepository _mentalPersonalRepository;
        private readonly IHistoriaclinicaRepository _historiaclinicaRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<MentalPersonal> _logger; 

        public MentalPersonalService(
            IMentalPersonalRepository mentalPersonalRepository,
            IMapper mapper,
            IHistoriaclinicaRepository historiaclinicaRepository
            )
        {
            _mentalPersonalRepository = mentalPersonalRepository;
            _historiaclinicaRepository = historiaclinicaRepository;
            _mapper = mapper;
        }
         
        public async Task Actualizar(int Id, MentalPersonalDTO mentalPersonalDTO)
        {
            try
            {
                var existe = await _historiaclinicaRepository.GetById(mentalPersonalDTO.IdHistoriaClinica);
                if (existe == null)
                {
                    throw new Exception("No existe la historia clinica");
                }

                var signosFisicos = await _mentalPersonalRepository.GetById(Id);

                if (signosFisicos == null) { throw new Exception("No existe los signos fisicos"); }

                _mapper.Map(mentalPersonalDTO, signosFisicos);
                signosFisicos.FechaActualizacion = DateTime.Now;
                
                await _mentalPersonalRepository.ActualizarAsync(signosFisicos);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar signos fisicos");
                throw;
            }
        }

        public async Task Crear(MentalPersonalDTO mentalPersonalDTO)
        {
            try
            {
                var existe = await _historiaclinicaRepository.GetById(mentalPersonalDTO.IdHistoriaClinica);
                if (existe == null)
                {
                    throw new Exception("No existe la historia clinica");
                }

                MentalPersonal mentalPersonal = _mapper.Map<MentalPersonal>(mentalPersonalDTO);
                mentalPersonal.FechaCreacion = DateTime.Now;
                mentalPersonal.IdUsuarioCreacion = mentalPersonalDTO.IdUsuario;
                
                await _mentalPersonalRepository.CrearAsync(mentalPersonal);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error al crear Mental Personal");
                throw;
            }
        }

        public async Task<MentalPersonal> GetByHistoriaClinica(int idHistoriaClinica)
        {
            return await _mentalPersonalRepository.GetByHistoriaClinica(idHistoriaClinica);
        }
    }
 
}
