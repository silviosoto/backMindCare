using API.Models;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class FacturaDto
    {
        public int IdPaciente { get; set; }          
        public int? IdPsicologo { get; set; }         
        public DateTime FechaEmision { get; set; }
        public List<FacturaDetalleDto> Detalles { get; set; }

    }
}
