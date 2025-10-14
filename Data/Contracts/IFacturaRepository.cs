using DAL.Tools;
using Domain.DTO;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface IFacturaRepository
    {
        Task<Factura> CrearFacturaAsync(Factura factura);
        Task<int> ObtenerConsecutivoAsync();
        Task<PagedResult<ReportFacturaDTO>> GetFacturasPaginado(int page , int pageSize );
        Task<PagedResult<ReportFacturaDTO>> GetFacturasbyClient(int Idpaciente, int page = 0, int pageSize = 10);
        Task<Factura> GetFacturasbyId(int IdFactura);
        Task<Boolean> IsTerapiaFacturada(int Idterapia);
        Task<PagedResult<paymethpsychologistDTO>> GetPaymethPsychologist(int idPsicologo, DateTime Fechainicio,
            DateTime Fechafin, int page = 0, int pageSize = 10);
    }
}
