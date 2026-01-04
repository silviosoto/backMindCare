using AutoMapper;
using BLL.Contracts;
using BLL.DTOs;
using DAL.Contracts;
using Domain.Models;
using Microsoft.Extensions.Logging;

namespace BLL.Servicio
{
    public class TerapiaSevices : ITerapiaService
    {
        private readonly ITerapiaRepository _terapiaRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<TerapiaSevices> _logger; 

        public TerapiaSevices(
            ITerapiaRepository terapiaRepository,
            IMapper mapper
            )
        {
            _terapiaRepository = terapiaRepository;
            _mapper = mapper; 
        }

        public async Task<Terapia> Crear(Terapia factura)
        {
            return await _terapiaRepository.CrearAsync(factura);
        }
    }
}
