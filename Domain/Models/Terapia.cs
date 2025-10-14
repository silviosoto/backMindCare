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
    public class Terapia
    {
        public int Id { get; set; }  
        public int idPaciente { get; set; }
        public int Idpsicologo { get; set; }
        public int Idservicio { get; set; }
        public int NumeroSesiones { get; set; }
        public decimal valor { get; set; }
        public Boolean espaquete { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public int ? IdUsuarioActualizacion { get; set; }
        public Boolean Estado { get; set; }
        public Paciente Paciente { get; set; }
        public Psicologo Psicologo { get; set; }
        public Servicio Servicio { get; set; }
        //public Cita cita { get; set; } = null!;
    }
}
