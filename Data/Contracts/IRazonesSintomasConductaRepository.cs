using Domain.Models;

namespace DAL.Contracts
{
    public interface IRazonesSintomasConductaRepository
    {
        Task CrearAsync(RazonesSintomasConducta razonesSintomasConducta);
        Task<RazonesSintomasConducta> ActualizarAsync(RazonesSintomasConducta razonesSintomasConducta);
        Task<RazonesSintomasConducta> GetById(int id);
        Task<RazonesSintomasConducta> GetByHistoriaClinica(int id);
    }
}
