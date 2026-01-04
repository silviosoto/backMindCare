
using AutoMapper;
using BLL.Contracts;
using BLL.DTOs;
using DAL.Contracts;
using Domain.Models;
using Microsoft.Extensions.Logging;

namespace BLL.Servicio
{
    public class SignosFisicosService : ISignosFisicosService
    {
        private readonly ISignosFisicosRepository _signosFisicosRepository;
        private readonly IHistoriaclinicaRepository _historiaclinicaRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<SignosFisicos> _logger; 

        public SignosFisicosService(ISignosFisicosRepository signosFisicosRepository,
            IMapper mapper,
            IHistoriaclinicaRepository historiaclinicaRepository
            )
        {
            _signosFisicosRepository = signosFisicosRepository;
            _historiaclinicaRepository = historiaclinicaRepository;
            _mapper = mapper;
        }

      
        public async Task ActualizarSignosFisicos(int Id, SignosFisicosDTO signosFisicosDTO)
        {
            try
            {
                var existe = await _historiaclinicaRepository.GetById(signosFisicosDTO.IdHistoriaClinica);
                if (existe == null)
                {
                    throw new Exception("No existe la historia clinica");
                }

                var signosFisicos = await _signosFisicosRepository.GetById(Id);

                if (signosFisicos == null) { throw new Exception("No existe los signos fisicos"); }

                _mapper.Map(signosFisicosDTO, signosFisicos);
                signosFisicos.FechaActualizacion = DateTime.Now;
                
                _signosFisicosRepository.ActualizarAsync(signosFisicos);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar signos fisicos");
                throw;
            }

        }

        
        public async Task CrearSignosFisicos(SignosFisicosDTO signosFisicosCreateDTO)
        {
            try
            {
                var existe = await _historiaclinicaRepository.GetById(signosFisicosCreateDTO.IdHistoriaClinica);
                if (existe == null)
                {
                    throw new Exception("No existe la historia clinica");
                }

                SignosFisicos signosFisicos = _mapper.Map<SignosFisicos>(signosFisicosCreateDTO);
                signosFisicos.FechaCreacion = DateTime.Now;
                signosFisicos.IdUsuarioCreacion = signosFisicosCreateDTO.IdUsuario;
                
                await _signosFisicosRepository.CrearAsync(signosFisicos);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error al crear signos fisicos");
                throw;
            }
        }
    }
 
}
