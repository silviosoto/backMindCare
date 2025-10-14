using Domain.Models;

namespace DAL.Contracts
{
    public interface IDesarrolloPsicosexualRepository
    {
        Task CrearAsync(DesarrolloPsicosexual desarrolloPsicosexual);
        Task<DesarrolloPsicosexual> ActualizarAsync(DesarrolloPsicosexual desarrolloPsicosexual);
        Task<DesarrolloPsicosexual> GetById(int id);
        Task<DesarrolloPsicosexual> GetByHistoriaClinica(int id);
    }
}
