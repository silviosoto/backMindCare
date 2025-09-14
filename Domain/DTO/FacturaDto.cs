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
        public int IdPaciente { get; set; }          // ID del paciente/cliente
        public int IdPsicologo { get; set; }        // ID del psicólogo
        public DateTime FechaEmision { get; set; }   // Fecha de generación
        public List<FacturaDetalleDto> Detalles { get; set; }

    }
}
