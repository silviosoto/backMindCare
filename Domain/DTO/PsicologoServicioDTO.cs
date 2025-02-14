using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class PsicologoServicioDTO
    {
        public int IdUser { get; set; }
        public int IdServicio { get; set; }
        public decimal Valor { get; set; }
    }
}
