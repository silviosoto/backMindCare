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
        public int IdServicio { get; set; }
        public int IdTerapia { get; set; }
        public decimal ValorServicio { get; set; }
        public TimeSpan Hora { get; set; }
        public DateTime? Fecha { get; set; }
        public string MotivoConsulta { get; set; }
        public int sesiones { get; set; }
        public Boolean ispaquete { get; set; }
    }
}
