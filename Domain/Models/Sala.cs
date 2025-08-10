using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Sala
    {
        public int Id { get; set; }
        public int IdCita { get; set; }
        public string? UrlHost { get; set; }
        public string? TokenHost { get; set; }
        public string? UrlHuesped { get; set; }
        public string? TokenHuesped { get; set; }
        public DateTime fechahora { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public Cita cita { get; set; }
      
    }
}
