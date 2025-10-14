using Domain.Models;

namespace DAL.Contracts
{
    public interface IMentalPersonalRepository
    {
        Task CrearAsync(MentalPersonal mentalPersonal);
        Task<MentalPersonal> ActualizarAsync(MentalPersonal mentalPersonal);
        Task<MentalPersonal> GetById(int id);
        Task<MentalPersonal> GetByHistoriaClinica(int id);

    }
}
