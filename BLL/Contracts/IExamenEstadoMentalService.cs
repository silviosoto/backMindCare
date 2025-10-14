
using BLL.DTOs;
using Domain.Models;
namespace BLL.Contracts
{
    public interface IExamenEstadoMentalService
    {
        public Task Crear(ExamenEstadoMentalDTO examenEstadoMentalDTO);    

        Task Actualizar(int Id, ExamenEstadoMentalDTO examenEstadoMentalDTO);

        Task<ExamenEstadoMental> GetByHistoriaClinica(int idHistoriaClinica);
    }
}
