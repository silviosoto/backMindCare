using Domain.Models;

namespace DAL.Contracts
{
    public interface ISignosFisicosRepository
    {
        Task CrearAsync(SignosFisicos signosFisicos);
        Task<SignosFisicos> ActualizarAsync(SignosFisicos signosFisicoss);
        Task<SignosFisicos> GetById(int id);

    }
}
