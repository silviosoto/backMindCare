using API.Models;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class SalaCreateDTO
    {
        public int IdCita { get; set; }
        public string UrlHost { get; set; }
        public string TokenHost { get; set; }
        public string UrlHuesped { get; set; }
        public string TokenHuesped { get; set; }
        public DateTime fechahora { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
