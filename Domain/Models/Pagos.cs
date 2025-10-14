using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Pagos
    {
        public int Id { get; set; }
        public int PsicologoId { get; set; }
        public int FacturaId { get; set; }
        public string TipoPago { get; set; } // "SESION_INDIVIDUAL" o "PAQUETE"
        public int? PaqueteId { get; set; }
        public int? NumeroSesion { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaPago { get; set; }
        public string Estado { get; set; }

        // Relaciones
        public Psicologo Psicologo { get; set; }
        public Factura Factura { get; set; }
        //public Paquete Paquete { get; set; }

    }
}
