
using BLL.DTOs;
using Domain.Models;
namespace BLL.Contracts
{
    public interface IDesarrolloPsicosexualService
    {
        public Task Crear(DesarrolloPsicosexualDTO desarrolloPsicosexualDTO);    
        Task Actualizar(int Id, DesarrolloPsicosexualDTO desarrolloPsicosexualDTO);
        Task<DesarrolloPsicosexual> GetByHistoriaClinica(int idHistoriaClinica);
    }
}
