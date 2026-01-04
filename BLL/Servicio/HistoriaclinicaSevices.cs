
using AutoMapper;
using BLL.Contracts;
using BLL.DTOs;
using DAL.Contracts;
using Domain.Models;
using Microsoft.Extensions.Logging;

namespace BLL.Servicio
{
    public class HistoriaclinicaSevices : IHistoriaClinicaService
    {
        private readonly IHistoriaclinicaRepository _historiaclinicaRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<FacturaSevices> _logger; 

        public HistoriaclinicaSevices(IHistoriaclinicaRepository historiaclinicaRepository,
            IMapper mapper
            )
        {
            _historiaclinicaRepository = historiaclinicaRepository;
            _mapper = mapper;
        }

        public async Task CrearHistoriaClinica(HistoriaClinicaCreateDto historiaClinicaCreateDto)
        {
            try
            {
                int  idpaciente = historiaClinicaCreateDto.IdPaciente;
                var existe = await _historiaclinicaRepository.GetByPaciente(idpaciente);
                if (existe != null)
                {
                    throw new Exception("El paciente ya tiene una historia clinica registrada");
                }
                HistoriaClinica historiaClinica = _mapper.Map<HistoriaClinica>(historiaClinicaCreateDto);
                historiaClinica.FechaCreacion = DateTime.Now;
                historiaClinica.Estado = 1; // Activo por defecto
                historiaClinica.IdUsuarioCreacion = 1;

                await _historiaclinicaRepository.CrearAsync(historiaClinica);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear Historia clinica ");
                throw;
            }
        }

        public async Task<HistoriaClinica> GetHistoriaClinicaById(int IdPaciente)
        {
           return await _historiaclinicaRepository.GetByPaciente(IdPaciente);
        }
    }
}
