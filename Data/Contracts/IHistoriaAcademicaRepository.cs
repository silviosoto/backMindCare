using Domain.Models;

namespace DAL.Contracts
{
    public interface IHistoriaAcademicaRepository
    {
        Task CrearAsync(HistoriaAcademica historiaAcademica);
        Task<HistoriaAcademica> ActualizarAsync(HistoriaAcademica historiaAcademica);
        Task<HistoriaAcademica> GetById(int id);
        Task<HistoriaAcademica> GetByHistoriaClinica(int id);
    }
}
