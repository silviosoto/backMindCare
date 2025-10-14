
using BLL.DTOs;
using Domain.Models;
namespace BLL.Contracts
{
    public interface IRazonesSintomasConductaService
    {
        public Task Crear(RazonesSintomasConductaDTO  razonesSintomasConductaDTO);    

        Task Actualizar(int Id, RazonesSintomasConductaDTO razonesSintomasConductaDTO);

        Task<RazonesSintomasConducta> GetByHistoriaClinica(int idHistoriaClinica);
    }
}
