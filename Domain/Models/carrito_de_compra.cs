using API.Models;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class carrito_de_compra
    {
        public int Id { get; set; }
        public int IdPsicologo { get; set; }
        public int IdPaciente { get; set; }
        public int IdServicio { get; set; }
        public bool EsPaquete { get; set; }
        public decimal ValorServicio { get; set; }
        public int NumeroSesiones { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int? IdUsuarioCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public int? IdUsuarioActualizacion { get; set; }
        public bool Estado { get; set; }
        public TimeSpan Hora { get; set; }
        public DateTime? Fecha { get; set; }
        public Psicologo Psicologo { get; set; }
        public Paciente Paciente { get; set; }
        public Servicio Servicio { get; set; }
        public User User { get; set; }
    }
}
