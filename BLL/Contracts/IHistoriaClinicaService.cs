
using BLL.DTOs;
using Domain.DTO;
using Domain.Models;
namespace BLL.Contracts
{
    public interface IHistoriaClinicaService
    {
        public Task CrearHistoriaClinica(HistoriaClinicaCreateDto historiaClinicaCreateDto);    

        Task<HistoriaClinica> GetHistoriaClinicaById(int IdPaciente);
    }
}
