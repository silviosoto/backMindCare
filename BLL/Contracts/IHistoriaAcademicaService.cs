
using BLL.DTOs;
using Domain.Models;
namespace BLL.Contracts
{
    public interface IHistoriaAcademicaService
    {
        public Task Crear(HistoriaAcademicaDTO historiaAcademicaDTO);    

        Task Actualizar(int Id, HistoriaAcademicaDTO historiaAcademicaDTO);

        Task<HistoriaAcademica> GetByHistoriaClinica(int idHistoriaClinica);
    }
}
