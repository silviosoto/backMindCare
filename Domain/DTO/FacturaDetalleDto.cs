using API.Models;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class FacturaDetalleDto
    {
        public int IdServicio { get; set; }                // ID del detalle de la factura
        public string Descripcion { get; set; }      // Ej: "Sesión de terapia"
        public int Cantidad { get; set; }           // Normalmente 1 por sesión
        public decimal ValorUnitario { get; set; }  // Precio antes de IVA
        public decimal PorcentajeIva { get; set; }  // 19% en Colombia (0.19m)
        public Boolean ispackage { get; set; } // Indica si es un paquete
    }
}
