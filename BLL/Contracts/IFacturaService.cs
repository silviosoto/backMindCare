using DAL.Tools;
using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BLL.Contracts
{
    public interface IFacturaService
    {
        public Task<Domain.Models.Factura> CrearFactura(FacturaDto factura);
        Task<PagedResult<ReportFacturaDTO>> GetFacturas(int page = 0, int pageSize = 10);
        Task<PagedResult<ReportFacturaDTO>> GetFacturasbyClient(int Idpaciente, int page = 0, int pageSize = 10);
        Task<byte[]> GenerarFacturaPdf(int IdFactura, string wwwRootPath);

    }
}
