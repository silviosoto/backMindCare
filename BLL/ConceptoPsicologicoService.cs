
using AutoMapper; 
using BLL.Contracts;
using BLL.DTOs;
using DAL.Contracts; 
using Domain.Models;
using Microsoft.Extensions.Logging;

namespace BLL
{
    public class ConceptoPsicologicoService : IConceptoPsicologicoService
    {
        private readonly IConceptoPsicologicoRepository _conceptoPsicologicoRepository;
        private readonly IHistoriaclinicaRepository _historiaclinicaRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<MentalPersonal> _logger; 

        public ConceptoPsicologicoService(
            IConceptoPsicologicoRepository conceptoPsicologicoRepository,
            IMapper mapper,
            IHistoriaclinicaRepository historiaclinicaRepository
            )
        {
            _conceptoPsicologicoRepository = conceptoPsicologicoRepository;
            _historiaclinicaRepository = historiaclinicaRepository;
            _mapper = mapper;
        }
         
        public async Task Actualizar(int Id, ConceptoPsicologicoDTO conceptoPsicologicoDTO)
        {
            try
            {
                var existe = await _historiaclinicaRepository.GetById(conceptoPsicologicoDTO.IdHistoriaClinica);
                if (existe == null)
                {
                    throw new Exception("No existe la historia clinica");
                }

                var signosFisicos = await _conceptoPsicologicoRepository.GetById(Id);

                if (signosFisicos == null) { throw new Exception("No existe los signos fisicos"); }

                _mapper.Map(conceptoPsicologicoDTO, signosFisicos);
                signosFisicos.FechaActualizacion = DateTime.Now;
                
                await _conceptoPsicologicoRepository.ActualizarAsync(signosFisicos);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar signos fisicos");
                throw;
            }
        }

        public async Task Crear(ConceptoPsicologicoDTO conceptoPsicologicoDTO)
        {
            try
            {
                var existe = await _historiaclinicaRepository.GetById(conceptoPsicologicoDTO.IdHistoriaClinica);
                if (existe == null)
                {
                    throw new Exception("No existe la historia clinica");
                }

                ConceptoPsicologico conceptoPsicologico = _mapper.Map<ConceptoPsicologico>(conceptoPsicologicoDTO);
                conceptoPsicologico.FechaCreacion = DateTime.Now;
                conceptoPsicologico.IdUsuarioCreacion = conceptoPsicologicoDTO.IdUsuario;
                
                await _conceptoPsicologicoRepository.CrearAsync(conceptoPsicologico);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error al crear Mental Personal");
                throw;
            }
        }

        public async Task<ConceptoPsicologico> GetByHistoriaClinica(int idHistoriaClinica)
        {
            return await _conceptoPsicologicoRepository.GetByHistoriaClinica(idHistoriaClinica);
        }
    }
 
}
