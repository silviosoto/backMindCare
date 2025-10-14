using API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Factura
    {
        public int Id { get; set; }
        public string NumeroFactura { get; set; }
        public DateTime FechaEmision { get; set; }
        public int idPaciente { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }
        public EstadoFactura Estado { get; set; } // "Pendiente", "Aprobada"
        public string? Cufe { get; set; } // UUID DIAN
        public string? QrCode { get; set; } // Base64 del QR
        public string? JsonDian { get; set; } // Respuesta DIAN 
        public Paciente Paciente { get; set; }
        //public Psicologo Psicologo { get; set; }
        public List<FacturaDetalle> FacturaDetalle { get; set; }
    }
}
