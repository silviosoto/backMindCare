using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Models;

namespace DAL.Tool
{
    public static class ToolDAL
    {

        public static string ObtenerNombreEstado(EstadoCita estado)
        {
            if (Enum.IsDefined(typeof(EstadoCita), estado))
            {
                return ((EstadoCita)estado).ToString(); // Convierte el número al nombre del estado
            }
            else
            {
                return "Estado desconocido"; // Si el estado no está definido
            }
        }
    }
}
