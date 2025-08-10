using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Cita
    {
        public int Id { get; set; }
        public int Idpsicologo { get; set; }
        public int Idpaciente { get; set; }
        public int Idservicio { get; set; }
        public TimeSpan Hora { get; set; }
        public EstadoCita Estado { get; set; }
        public DateTime? Fecha { get; set; }
        public DateTime? FechaCreacion { get; set; }  
        public DateTime? FechaActualizacion { get; set; }
        public Psicologo psicologo { get; set; }
        public Sala sala { get; set; }
        public Servicio servicio { get; set; }
        public Boolean? pagado { get; set; } = false;
        public string? MotivoConsulta { get; set; }
    }
}
