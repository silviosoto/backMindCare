using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class AgendaDTO
    { 
        public int IdUser { get; set; }
        public int DiaSemana { get; set; }
        public int mes { get; set; }
        public int anio { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; } 
         
    }
}
