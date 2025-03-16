using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class CitaCreateDTO
    {
        public int Idpsicologo { get; set; }
        public int Idpaciente { get; set; }
        public TimeSpan Hora { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
