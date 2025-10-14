
using BLL.DTOs;
using Domain.DTO;
using Domain.Models;
namespace BLL.Contracts
{
    public interface ISignosFisicosService
    {
        public Task CrearSignosFisicos(SignosFisicosDTO SignosFisicosCreateDTO);    

        Task ActualizarSignosFisicos(int Id, SignosFisicosDTO signosFisicos);
    }
}
