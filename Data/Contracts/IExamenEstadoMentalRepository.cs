using Domain.Models;

namespace DAL.Contracts
{
    public interface IExamenEstadoMentalRepository
    {
        Task CrearAsync(ExamenEstadoMental examenEstadoMental);
        Task<ExamenEstadoMental> ActualizarAsync(ExamenEstadoMental examenEstadoMental);
        Task<ExamenEstadoMental> GetById(int id);
        Task<ExamenEstadoMental> GetByHistoriaClinica(int id);

    }
}
