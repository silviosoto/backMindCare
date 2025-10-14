using Domain.Models;

namespace DAL.Contracts
{
    public interface IConceptoPsicologicoRepository
    {
        Task CrearAsync(ConceptoPsicologico conceptoPsicologico);
        Task<ConceptoPsicologico> ActualizarAsync(ConceptoPsicologico conceptoPsicologico);
        Task<ConceptoPsicologico> GetById(int id);
        Task<ConceptoPsicologico> GetByHistoriaClinica(int id);

    }
}
