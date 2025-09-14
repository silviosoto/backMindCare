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
    public class FacturaDetalle
    {
        public int Id { get; set; }
        public int IdFactura { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }
        public int IdServicio { get; set; }
        public Boolean ispackage { get; set; }
        public Servicio Servicio { get; set; }
        public Factura Factura { get; set; }
    }
}
