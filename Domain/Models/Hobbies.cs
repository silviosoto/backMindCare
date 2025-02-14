using API.Models;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Hobbies
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int IdUser { get; set; }
        public int IdDatosPersonales { get; set; }
        public bool Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public virtual DatosPersonale IdDatosPersonalesNavigation { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}
