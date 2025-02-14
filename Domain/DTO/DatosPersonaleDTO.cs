using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class DatosPersonaleDTO
    {
        public string? Nombre { get; set; }

        public string? Apellidos { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        public string? Email { get; set; }

        public string? Telefono { get; set; }
        public UserDTO User { get; set; }

    }
}
