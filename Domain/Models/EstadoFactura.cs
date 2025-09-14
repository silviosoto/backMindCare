using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public enum EstadoFactura
    {
        Borrador = 0,
        Generada = 1,
        Enviada = 2,
        Aceptada = 3,
        Rechazada = 4,
        Anulada = 5,
        Pagada = 6,
        Vencida = 7
    }
}
