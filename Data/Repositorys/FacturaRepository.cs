using API.Models;
using DAL.Contracts;
using DAL.Tools;
using Data.Models;
using Data.Repository;
using Domain.DTO;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<PagedResult<ReportFacturaDTO>> GetFacturasPaginado(int page = 0 , int pageSize = 10)
        {
            page = (page == 0) ? 1 : page;

            var facturas =  _context.Facturas
                .Include(f => f.FacturaDetalle)
                    .ThenInclude(f => f.Servicio)
                .Include(f => f.Psicologo)
                .Include(f => f.Paciente)
                    .ThenInclude(p => p.DatosPersonale)
                .OrderBy(x => x.Id);

            var totalRecords = await facturas.CountAsync();
             
            var FacturasPaginadas = await facturas
                .Select(f => new ReportFacturaDTO()
                {
                    Id= f.Id,
                    NumeroFactura = f.NumeroFactura,
                    FechaEmision = f.FechaEmision,
                    EstadoFactura = f.Estado.ToString(),
                    Subtotal = f.Subtotal,
                    Iva = f.Iva,
                    Total = f.Total,
                    Psicologo = new PsicologoDto
                    {
                        Nombre = f.Psicologo.IdDatosPersonalesNavigation.Nombre,
                        Apellidos =  f.Psicologo.IdDatosPersonalesNavigation.Apellidos,
                        NumeroId = f.Psicologo.IdDatosPersonalesNavigation.NumeroId
                    }, 
                    Paciente = new PacienteDto
                    {
                        Id= f.Paciente.Id,
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
                .Include(f => f.Psicologo)
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
                    Psicologo = new PsicologoDto
                    {
                        Nombre = f.Psicologo.IdDatosPersonalesNavigation.Nombre,
                        Apellidos = f.Psicologo.IdDatosPersonalesNavigation.Apellidos,
                        NumeroId = f.Psicologo.IdDatosPersonalesNavigation.NumeroId
                    },
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
                .Include(f => f.Psicologo)
                .Include(f => f.Paciente)
                    .ThenInclude(p => p.DatosPersonale)
                .Where(x => x.Id == IdFactura).FirstOrDefaultAsync();
            return factura;

        }

    }
}
