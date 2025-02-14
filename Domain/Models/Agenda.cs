using API.Models;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Agenda
    {
        public int Id { get; set; }
        public int Idpsicologo { get; set; }
        public int DiaSemana { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public bool Estado { get; set; }
        public int mes {  get; set; }
        public int anio {  get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public virtual Psicologo IdPsicologoNavigation { get; set; } = null!;
    }
}
