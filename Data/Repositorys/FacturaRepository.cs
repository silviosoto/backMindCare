using API.Models;
using DAL.Contracts;
using DAL.Tools;
using Data.Repository;
using Domain.DTO;
using Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DAL.Repositorys
{
    public class FacturaRepository : Repository<Factura>, IFacturaRepository
    {
        public readonly DbmindCareContext context;
        public FacturaRepository(DbmindCareContext context, ILogger<Repository<Factura>> logger) : base(context, logger)
        {
            this.context = context;
        }

        public async Task<Factura> CrearFacturaAsync(Factura factura)
        {
            _context.Facturas.Add(factura);
            await _context.SaveChangesAsync();
            return factura;
        }

        public async Task<int> ObtenerConsecutivoAsync()
        {
            return await _context.Facturas.CountAsync();
        }

        public async Task<PagedResult<ReportFacturaDTO>> GetFacturasPaginado(int page = 0, int pageSize = 10)
        {
            page = (page == 0) ? 1 : page;

            var facturas = _context.Facturas
                .Include(f => f.FacturaDetalle)
                    .ThenInclude(f => f.Servicio) 
                .Include(f => f.Paciente)
                    .ThenInclude(p => p.DatosPersonale)
                .OrderBy(x => x.Id);

            var totalRecords = await facturas.CountAsync();

            var FacturasPaginadas = await facturas
                .Select(f => new ReportFacturaDTO()
                {
                    Id = f.Id,
                    NumeroFactura = f.NumeroFactura,
                    FechaEmision = f.FechaEmision,
                    EstadoFactura = f.Estado.ToString(),
                    Subtotal = f.Subtotal,
                    Iva = f.Iva,
                    Total = f.Total,
                    Paciente = new PacienteDto
                    {
                        Id = f.Paciente.Id,
                        Nombre = f.Paciente.DatosPersonale.Nombre,
                        Apellidos = f.Paciente.DatosPersonale.Apellidos,
                        NumeroIdentificacion = f.Paciente.DatosPersonale.NumeroId
                    },
                    FacturaDetalle = f.FacturaDetalle.Select(fd => new FacturaDetalle
                    {
                        Id = fd.Id,
                        IdServicio = fd.IdServicio,
                        Descripcion = fd.Descripcion,
                        Cantidad = fd.Cantidad,
                        ValorUnitario = fd.ValorUnitario,
                        Iva = fd.Iva
                    }).ToList()
                })
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<ReportFacturaDTO>
            {
                Items = FacturasPaginadas,
                PageNumber = page,
                PageSize = pageSize,
                TotalRecords = totalRecords
            };

        }

        public async Task<PagedResult<ReportFacturaDTO>> GetFacturasbyClient(int Idpaciente, int page = 0, int pageSize = 10)
        {
            page = (page == 0) ? 1 : page;

            var facturas = _context.Facturas
                .Include(f => f.FacturaDetalle)
                    .ThenInclude(f => f.Servicio) 
                .Include(f => f.Paciente)
                    .ThenInclude(p => p.DatosPersonale)
                .Where(x => x.Paciente.Id == Idpaciente)
                .OrderBy(x => x.Id);

            var totalRecords = await facturas.CountAsync();

            var FacturasPaginadas = await facturas
                .Select(f => new ReportFacturaDTO()
                {
                    Id = f.Id,
                    NumeroFactura = f.NumeroFactura,
                    FechaEmision = f.FechaEmision,
                    EstadoFactura = f.Estado.ToString(),
                    Subtotal = f.Subtotal,
                    Iva = f.Iva,
                    Total = f.Total,
                    Paciente = new PacienteDto
                    {
                        Id = f.Paciente.Id,
                        Nombre = f.Paciente.DatosPersonale.Nombre,
                        Apellidos = f.Paciente.DatosPersonale.Apellidos,
                        NumeroIdentificacion = f.Paciente.DatosPersonale.NumeroId
                    },
                    FacturaDetalle = f.FacturaDetalle.Select(fd => new FacturaDetalle
                    {
                        Id = fd.Id,
                        IdServicio = fd.IdServicio,
                        Descripcion = fd.Servicio != null ? fd.Servicio.Nombre : string.Empty,
                        Cantidad = fd.Cantidad,
                        ValorUnitario = fd.ValorUnitario,
                        Iva = fd.Iva
                    }).ToList()
                })
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<ReportFacturaDTO>
            {
                Items = FacturasPaginadas,
                PageNumber = page,
                PageSize = pageSize,
                TotalRecords = totalRecords
            };

        }

        public async Task<Factura> GetFacturasbyId(int IdFactura)
        {
            var factura = await _context.Facturas
                .Include(f => f.FacturaDetalle)
                    .ThenInclude(f => f.Servicio)
                .Include(f => f.Paciente)
                    .ThenInclude(p => p.DatosPersonale)
                .Where(x => x.Id == IdFactura).FirstOrDefaultAsync();
            return factura;
        }


        public async Task<PagedResult<paymethpsychologistDTO>> GetPaymethPsychologist( 
            int idPsicologo,
            DateTime Fechainicio,
            DateTime Fechafin ,
            int PageNumber = 0, 
            int PageSize = 10)
        {
            PageNumber = (PageNumber == 0) ? 1 : PageNumber;
            var totalRecordsParam = new SqlParameter
            {
                ParameterName = "@TotalRecords",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output
            };

            DateTime minSqlDate = new DateTime(1753, 1, 1);
         
            var citas = await context.Database.SqlQueryRaw<paymethpsychologistDTO>(
                          "EXEC paymethpsychologist @idPsicologo, @Fechainicio,@Fechafin,@PageNumber,@PageSize,@TotalRecords OUTPUT",
                          new SqlParameter("@idPsicologo", idPsicologo),
                          new SqlParameter("@Fechainicio", (Fechainicio < minSqlDate) ? DBNull.Value: Fechainicio),
                          new SqlParameter("@Fechafin",(Fechafin < minSqlDate) ? DBNull.Value : Fechafin),
                          new SqlParameter("@PageNumber", PageNumber),
                          new SqlParameter("@PageSize", PageSize),
                          totalRecordsParam
                          ).ToListAsync();

            int totalRecords = (int)totalRecordsParam.Value;

            return new PagedResult<paymethpsychologistDTO>
            {
                Items = citas,
                PageNumber = PageNumber,
                PageSize = PageSize,
                TotalRecords = totalRecords
            };
        }

        public async Task<bool> IsTerapiaFacturada(int Idterapia)
        {
             bool existe = await _context.Facturas
                .AnyAsync(f => f.Estado == EstadoFactura.Pagada  &&
                               f.FacturaDetalle.Any(d => d.IdTerapia == Idterapia));
            return existe;
        }
    }
}
