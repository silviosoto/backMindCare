
using BLL.DTOs;
using Domain.Models;
namespace BLL.Contracts
{
    public interface IConceptoPsicologicoService
    {
        public Task Crear(ConceptoPsicologicoDTO conceptoPsicologicoDTO);    

        Task Actualizar(int Id, ConceptoPsicologicoDTO conceptoPsicologicoDTO);

        Task<ConceptoPsicologico> GetByHistoriaClinica(int idHistoriaClinica);
    }
}
