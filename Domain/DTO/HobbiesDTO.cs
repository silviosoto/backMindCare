using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class HobbiesDTO
    {
        public int IdUser { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public bool Estado { get; set; }
    }
}
