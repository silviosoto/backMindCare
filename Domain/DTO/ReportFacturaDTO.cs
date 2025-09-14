using API.Models;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class ReportFacturaDTO
    {
        public int Id { get; set; }
        public string NumeroFactura { get; set; }
        public DateTime FechaEmision { get; set; }
        public string EstadoFactura { get; set; } 
        public decimal Subtotal { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }
        public PsicologoDto Psicologo { get; set; }
        public PacienteDto Paciente { get; set; }
        public List<FacturaDetalle> FacturaDetalle { get; set; }
    }

    public class PsicologoDto
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string NumeroId { get; set; }
    }

    public class PacienteDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string NumeroIdentificacion { get; set; }
    }
}
