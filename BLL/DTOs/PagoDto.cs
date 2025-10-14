using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public  class PagoDto
    {
        public int PsicologoId { get; set; }
        public int FacturaId { get; set; }
        public string TipoPago { get; set; }
        public int? PaqueteId { get; set; }
        public int? NumeroSesion { get; set; }
        public decimal Monto { get; set; }
    }
}
