using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class DetalleFacturaDto
    {
        public int IdServicio { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal PorcentajeIVA { get; set; }
        public decimal PorcentajeICO { get; set; }
    }
}
