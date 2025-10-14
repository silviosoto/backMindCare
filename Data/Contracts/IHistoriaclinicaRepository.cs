using Domain.Models;

namespace DAL.Contracts
{
    public interface IHistoriaclinicaRepository
    {
        Task CrearAsync(HistoriaClinica factura);
        Task<HistoriaClinica> GetByPaciente(int paciente);
        Task<HistoriaClinica> GetById(int Id);
        Task<HistoriaClinica> ActualizarAsync(HistoriaClinica factura);

    }
}
