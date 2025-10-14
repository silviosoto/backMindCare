
using AutoMapper; 
using BLL.Contracts;
using BLL.DTOs;
using DAL.Contracts; 
using Domain.Models;
using Microsoft.Extensions.Logging;

namespace BLL
{
    public class RazonesSintomasConductaService : IRazonesSintomasConductaService
    {
        private readonly IRazonesSintomasConductaRepository _razonesSintomasConductaRepository;
        private readonly IHistoriaclinicaRepository _historiaclinicaRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<MentalPersonal> _logger; 

        public RazonesSintomasConductaService(
            IRazonesSintomasConductaRepository razonesSintomasConductaRepository,
            IMapper mapper,
            IHistoriaclinicaRepository historiaclinicaRepository
            )
        {
            _razonesSintomasConductaRepository = razonesSintomasConductaRepository;
            _historiaclinicaRepository = historiaclinicaRepository;
            _mapper = mapper;
        }
         
        public async Task Actualizar(int Id, RazonesSintomasConductaDTO razonesSintomasConductaDTO)
        {
            try
            {
                var existe = await _historiaclinicaRepository.GetById(razonesSintomasConductaDTO.IdHistoriaClinica);
                if (existe == null)
                {
                    throw new Exception("No existe la historia clinica");
                }

                var razonesSintomasConducta = await _razonesSintomasConductaRepository.GetById(Id);

                if (razonesSintomasConducta == null) { throw new Exception("No existen las razones de conducta"); }

                _mapper.Map(razonesSintomasConductaDTO, razonesSintomasConducta);
                razonesSintomasConducta.FechaActualizacion = DateTime.Now;
                
                await _razonesSintomasConductaRepository.ActualizarAsync(razonesSintomasConducta);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar razones de conducta");
                throw;
            }
        }

        public async Task Crear(RazonesSintomasConductaDTO razonesSintomasConductaDTO)
        {
            try
            {
                var existe = await _historiaclinicaRepository.GetById(razonesSintomasConductaDTO.IdHistoriaClinica);
                if (existe == null)
                {
                    throw new Exception("No existe la historia clinica");
                }

                RazonesSintomasConducta razonesSintomasConducta = _mapper.Map<RazonesSintomasConducta>(razonesSintomasConductaDTO);
                razonesSintomasConducta.FechaCreacion = DateTime.Now;
                razonesSintomasConducta.IdUsuarioCreacion = razonesSintomasConductaDTO.IdUsuario;
                
                await _razonesSintomasConductaRepository.CrearAsync(razonesSintomasConducta);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error al crear razones de conducta");
                throw;
            }
        }

        public async Task<RazonesSintomasConducta> GetByHistoriaClinica(int idHistoriaClinica)
        {
            return await _razonesSintomasConductaRepository.GetByHistoriaClinica(idHistoriaClinica);
        }
    }
 
}
