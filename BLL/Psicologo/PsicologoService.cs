using API.Models;
using AutoMapper;
using DAL.Helper;
using DAL.Repositorys;
using Data.Contracts;
using Domain.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using API.Models.DTOs;

namespace BLL.PsicologoBll
{
    public class PsicologoService
    {
        private readonly PsicologoRepositorio _psicologoRepository;
        private readonly IMapper _mapper;

        public PsicologoService(PsicologoRepositorio psicologoRepository, IMapper mapper)
        {
            _psicologoRepository = psicologoRepository;
            _mapper = mapper;
        }

        public async Task<Psicologo> GetPsicologoByUser(int id)
        {
            var datos_personales =  await _psicologoRepository.context.Users.
                Include(u => u.IdDatosPersonalesNavigation)
                .Where(x => x.Id == id)
                .Select(u => new { u.IdDatosPersonalesNavigation.Id })
                .FirstOrDefaultAsync();

            return await _psicologoRepository.GetPsicologoConRelacionesAsync(datos_personales.Id);
        }

        public async Task<Psicologo?> GetPsicologoById(int id)
        {
                return await _psicologoRepository.context.Psicologos
                .Include(u => u.IdDatosPersonalesNavigation)
                    .ThenInclude(h => h.Hobbies)                
                .Where(x => x.Id == id  )
                .FirstOrDefaultAsync();
           
        }

        public Task AddPsicologo(Psicologo psicologo)
        {
            return _psicologoRepository.AddAsync(psicologo);
        }

        public void UpdatePsicologo(Psicologo psicologo)
        {
            _psicologoRepository.UpdateAsync(psicologo);
        }

        public void DeletePsicologo(int id)
        {
            _psicologoRepository.SoftDeleteAsync(id);
        }

        public async Task<PaginatedList<Psicologo>> GetPaginatedEntities(int pageNumber, int pageSize)
        {
            return await _psicologoRepository.GetPaginatedResult(pageNumber, pageSize);
        }

        public async Task<Psicologo> InsertService(PsicologoServicioDTO  psicologoServicioDTO)
        {
            try
            {
                // validar si existe el servicio y si ya tiene el servicio asociado
                Psicologo psicologo = await GetPsicologoByUser(psicologoServicioDTO.IdUser);
                
                if (psicologo != null)
                {
                    Boolean exist = await _psicologoRepository.ExistServiceAsociatedToPsicology(psicologo.Id, psicologoServicioDTO.IdServicio);
                    if (exist)
                    {
                        throw new ArgumentException("El psicologo ya tiene este servicio asociado");
                    }

                    PsicologoServicio psicologoServicio = new PsicologoServicio();
                    psicologoServicio.IdPsicologo = psicologo.Id;
                    psicologoServicio.IdServicio = psicologoServicioDTO.IdServicio;
                    psicologoServicio.Valor = psicologoServicioDTO.Valor;
                    psicologoServicio.FechaCreacion = DateTime.Now;

                    await _psicologoRepository.InsertPsicologoServicio(psicologoServicio);
                    var s = await _psicologoRepository.GetByIdAsync(psicologo.Id);
                    return s;
                }
                else
                {
                    throw new ArgumentNullException("Psicologo no encontrado");
                }
            }
            catch(Exception e) {

                throw new BLLException(e.Message, e);
            }

        }

        public async Task<List<GetServiciosDTO>> GetServicios(int psicologoId, int pageNumber)
        {
            try
            {
                var result = await _psicologoRepository.GetServicios(psicologoId, pageNumber);

                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<GetServiciosDTO>> GetServicios(int psicologoId )
        {
            try
            {
                var result = await _psicologoRepository.GetServicios(psicologoId);

                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> DeletePsicologoServicio(int psicologoServicioId)
        {
            try
            {
               return  await _psicologoRepository.DeletePsicologoServicio(psicologoServicioId);
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public async Task<bool> UpdatePsicologoServicio( int idPsicologoServicio , UpdatePsicologoServiciosDTO updatePsicologoServiciosDTO)
        {
            try
            {
                var psicologoservicio = await _psicologoRepository.
                    FindPsicologoServicioById(idPsicologoServicio);
                
                if (psicologoservicio == null) { return false; }
                _mapper.Map(updatePsicologoServiciosDTO, psicologoservicio);
                psicologoservicio.FechaActualizacion = DateTime.Now;

                return await _psicologoRepository.UpdatePsicologoServicios(psicologoservicio);
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public async Task<List<PsicologoListDTO>> GetPsicologos(int pageNumber, int pageSize)
        {
            try
            {
                var listPsicologo = await _psicologoRepository.GetPsicologo(pageNumber, pageSize);
                
                if (listPsicologo == null) {
                    return null;
                }

               // var newlist = listPsicologo.Select(ps => new PsicologoListDTO
               // {

               //     Id = ps.Id,
               //     Nombre = ps.Nombre,
               //     Apellidos = ps.Apellidos,
               //     Experiencia = ps.Experiencia,
               //     Descripcion = ps.Descripcion,
               //     ImagePerfil = GetImage(ps.ImagePerfil)

               //}).ToList();

                foreach (var item in listPsicologo)
                {
                    if (item.ImagePerfil != null)
                    {
                        item.ImagePerfil = GetImage(item.ImagePerfil);
                    }
                }

                return listPsicologo;

            }
            catch (Exception e)
            {
                return null;
            }
        }

        private string GetImage(string pahtName)
        {
            var filePath = Path.Combine("wwwroot/uploads", pahtName);
            var imageBytes = System.IO.File.ReadAllBytes(filePath);
            var base64Image = Convert.ToBase64String(imageBytes);

            if (base64Image != null)
            {
                return base64Image;
            }

            return null;
        }



    }
}
