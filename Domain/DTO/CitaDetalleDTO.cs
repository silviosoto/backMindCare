using API.Models;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class CitaDetalleDTO
    {
        public int Id { get; set; }
        public DateTime? Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public EstadoCita Estado { get; set; }
        public string EstadoString { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string? ImagePerfil { get; set; }
        public int Experiencia { get; set; }
        public string? MotivoConsulta { get; set; }
        public string? Url { get; set; }
        public string? Token { get; set; }
        public string Servicio { get; set; }
    }
}
