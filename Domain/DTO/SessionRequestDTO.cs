using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class SessionRequestDTO
    {
        public int PacienteId { get; set; }   // ID del psicólogo
        public int PsicologoId { get; set; }  // ID del paciente
        public DateTime HoraCita { get; set; }
        public int IdCita { get; set; }
    }
}
