using API.Models;
using AutoMapper;
using DAL.Repositorys;
using Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicio
{
    public class ServicioService
    {
        private readonly ServicioRepository _servicioRepository;
        private readonly IMapper _mapper;

        public ServicioService(ServicioRepository ServicioRepository, IMapper mapper)
        {
            _servicioRepository = ServicioRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<API.Models.Servicio>> SearchCoincenceServiceName(string nombre)
        {
            var datos_personales = await _servicioRepository.SearchCoincenceServiceName(nombre);

            return datos_personales;
        }

        public async Task<IEnumerable<API.Models.Servicio>> GetAllServicio()
        {
            var servicios = await _servicioRepository.GetAllAsync();
            return servicios;
        }
        public async Task<API.Models.Servicio> GetServicioById( int id )
        {
            var servicio = await _servicioRepository.GetByIdAsync(id);
            return servicio;
        }

    }
}
