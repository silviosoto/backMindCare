using BLL.DTOs;
using Domain.Models;

namespace BLL.Contracts
{
    public interface ITerapiaService
    {
        public Task<Terapia> Crear(Terapia factura); 
    }
}
