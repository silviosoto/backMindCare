using API.Models;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class CitaDTO
    { 
        public TimeSpan HoraInicio { get; set; }
        public EstadoCita Estado {  get; set; }
         
    }
}
