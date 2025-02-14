using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositorys;
using Microsoft.Extensions.Logging;
using AutoMapper; 
using Domain.Models;
using Domain.DTO;
using API.Models;
using Data.Models;
using Data.Contracts;

namespace BLL.HobbiesBLL
{
    public class HobbiesSevices
    {
        private readonly HobbiesRepository _hobiesRepopsitory;
        private readonly IMapper _mapper;

        public HobbiesSevices(HobbiesRepository hobiesRepopsitory, IMapper mapper)
        {
            _hobiesRepopsitory = hobiesRepopsitory;
            _mapper = mapper;
        }

        public async Task<Hobbies>Insert(HobbiesDTO hobbiesDTO)
        {
            try
            {

                // buscar datos personales por usuario
                int IdDatosPersonales = await _hobiesRepopsitory.GetDatosPersonales(hobbiesDTO.IdUser);
                Hobbies hobbies = _mapper.Map<Hobbies>(hobbiesDTO);
                hobbies.FechaCreacion = DateTime.Now;
                hobbies.IdDatosPersonales = IdDatosPersonales;
                await _hobiesRepopsitory.AddAsync(hobbies);
                return hobbies;
            }
            catch (Exception e)
            {
                throw new BLLException(e.Message, e);
            }
        }

        public async Task SoftDeleteAsync(int Id)
        {
            await _hobiesRepopsitory.SoftDeleteAsync(Id);
        }
        public async Task<List<Hobbies>> GethobbiesByUser(int IdUser)
        {
            try
            {
                
                return await _hobiesRepopsitory.GetHobbiesByUser(IdUser);
                  
            }
            catch (Exception e)
            {
                throw new BLLException(e.Message, e);
            }
        }

        public async Task<Hobbies> GetHobbieById(int id)
        {
            var servicio = await _hobiesRepopsitory.GetByIdAsync(id);
            return servicio;
        }

        public async Task<IEnumerable<Hobbies>> GetAll()
        {
            var Hobbies = await _hobiesRepopsitory.GetAllAsync();
            return Hobbies;
        }

        public async Task<bool> Update(int id, HobbiesDTO hobbiesDTO)
        {
            try
            {
                var hobbie = await _hobiesRepopsitory.GetByIdAsync(id);

                if (hobbie == null) { return false; }
                _mapper.Map(hobbiesDTO, hobbie);
                hobbie.FechaActualizacion = DateTime.Now;

                await _hobiesRepopsitory.UpdateAsync(hobbie);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
