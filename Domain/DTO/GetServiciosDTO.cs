using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class GetServiciosDTO
    {
        public int Id { get; set; }
        public int PsicologoId { get; set; }
        public decimal Valor { get; set; }
        public int ServicioId { get; set; } 
        public string ServicioNombre { get; set; } = string.Empty;  
 
    }
}
