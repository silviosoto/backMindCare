using API.Models;
using Data.Contracts;
using Data.Models;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Domain.DTO;
using API.Models.DTOs;

namespace DAL.Repositorys
{
    public class PsicologoRepositorio : Repository<Psicologo>, IPsicologoRepository
    {
        public readonly DbmindCareContext context;

        public PsicologoRepositorio(DbmindCareContext context, ILogger<Repository<Psicologo>> logger) : base(context, logger)
        {
            this.context = context;
        }

        public IEnumerable<Psicologo> GetProductsByCategory(int categoryId)
        {
            return _dbSet.Where(p => p.Id == categoryId).ToList();
        }

        public Psicologo GetMostExpensiveProduct()
        {
            return _dbSet.OrderByDescending(p => p.Id).FirstOrDefault();
        }

        public async Task<Psicologo> GetPsicologoConRelacionesAsync(int id)
        {

            return await _context.Psicologos
                .Include(p => p.IdDatosPersonalesNavigation) // Incluyendo relación 1 a 1 con DatosPersonale
                .Include(p => p.PsicologoEspecialidads)      // Incluyendo relación 1 a muchos con PsicologoEspecialidad
                .Include(p => p.PsicologoIdiomas)
                    .ThenInclude(i => i.IdIdiomaNavigation)// Incluyendo relación 1 a muchos con PsicologoIdiomas
                .Include(p => p.PsicologoServicios)          // Incluyendo relación 1 a muchos con PsicologoServicios
                .FirstOrDefaultAsync(p => p.IdDatosPersonales == id);
        }

        public async Task InsertPsicologoServicio(PsicologoServicio psicologoServicio)
        {

            context.PsicologoServicios.AddAsync(psicologoServicio);
            context.SaveChanges();
        } 
         
        
        public async Task<List<GetServiciosDTO>> GetServicios(int userId, int pageNumber)
        {
            //var pageNumber = 1;
            var pageSize = 10;

            var user =  await context.Users
                .FirstOrDefaultAsync(u => u.Id == userId);
            
            if (user == null) return null;

           return   await context.PsicologoServicios
            .Include(ps => ps.IdPsicologoNavigation)
            .Include(ps => ps.IdServicioNavigation)
            .Where(p => p.IdPsicologoNavigation.IdDatosPersonales == user.IdDatosPersonales
             && p.Estado != false)
            .Select(ps => new GetServiciosDTO
            {
                Id = ps.Id,
                PsicologoId = ps.IdPsicologo,
                Valor = (decimal)ps.Valor,
                ServicioId = ps.IdServicio,
                ServicioNombre = ps.IdServicioNavigation.Nombre
            })
            .AsNoTracking()
            .OrderBy(e => e.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
 
        }

        public async Task<List<GetServiciosDTO>> GetServicios(int psicologoId)
        {
            
            return await context.PsicologoServicios
             .Include(ps => ps.IdPsicologoNavigation)
             .Include(ps => ps.IdServicioNavigation)
             .Where(p =>  p.IdPsicologo == psicologoId
              && p.Estado != false)
             .Select(ps => new GetServiciosDTO
             {
                 Id = ps.Id,
                 PsicologoId = ps.IdPsicologo,
                 Valor = (decimal)ps.Valor,
                 ServicioId = ps.IdServicio,
                 ServicioNombre = ps.IdServicioNavigation.Nombre
             })
             .AsNoTracking()
             .OrderBy(e => e.Id) 
             .ToListAsync();

        }

        public async Task<Boolean> DeletePsicologoServicio( int id) 
        {

            try
            {
                var entity = await context.PsicologoServicios.FindAsync(id);
                if (entity == null)
                {
                    return false;
                }
                
                entity.Estado = false;
                entity.FechaActualizacion = DateTime.Now;
                _context.PsicologoServicios.Update(entity);
                
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
              return false;
            }
        }

       public async Task<PsicologoServicio> FindPsicologoServicioById( int Id)
       {
            try
            {
                PsicologoServicio psicologo = await context.PsicologoServicios
                    .FirstOrDefaultAsync(x => x.Id == Id);
                
                return psicologo == null ? null : psicologo;
            
            }catch(Exception ex)
            {
                return null;
            }
       }

       public async Task<Boolean> ExistServiceAsociatedToPsicology(int IdPsicologo, int IdServicio)
        {
            try
            {
                PsicologoServicio? psicologo = await context.PsicologoServicios
                    .FirstOrDefaultAsync(x => x.IdPsicologo == IdPsicologo  && x.IdServicio == IdServicio);

                return psicologo == null ? false : true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Boolean> UpdatePsicologoServicios(PsicologoServicio psicologoServicio)
       {
            try
            {
                _context.Entry(psicologoServicio).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
       }
        
        public async Task<List<PsicologoListDTO>> GetPsicologo(int pageNumber, int pageSize = 10)
        {
            try
            {

                return await _context.Psicologos
                 .Include(p => p.IdDatosPersonalesNavigation)
                 .Include(p => p.PsicologoEspecialidads)
                 .Include(p => p.PsicologoIdiomas)
                     .ThenInclude(i => i.IdIdiomaNavigation)
                 .Include(p => p.PsicologoServicios)
                 .Where(x => x.Validado == "1" && x.Estado == true)
                    .Select(ps => new PsicologoListDTO
                    {
                        Id = ps.Id,
                        Nombre = ps.IdDatosPersonalesNavigation.Nombre,
                        Apellidos = ps.IdDatosPersonalesNavigation.Apellidos,
                        Experiencia = ps.Experiencia,
                        Descripcion = ps.Descripcion,
                        ImagePerfil = ps.ImagePerfil 
                    })
                 .AsNoTracking()
                 .OrderBy(e => e.Id)
                 .Skip((pageNumber - 1) * pageSize).Take(pageSize)
                 .ToListAsync();

            }
            catch (Exception ex)
            {
                return null;
            }
           
        }

    }

}
