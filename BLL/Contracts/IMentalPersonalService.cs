
using BLL.DTOs;
using Domain.Models;
namespace BLL.Contracts
{
    public interface IMentalPersonalService
    {
        public Task Crear(MentalPersonalDTO mentalPersonalDTO);    

        Task Actualizar(int Id, MentalPersonalDTO mentalPersonalDTO);

        Task<MentalPersonal> GetByHistoriaClinica(int idHistoriaClinica);
    }
}
