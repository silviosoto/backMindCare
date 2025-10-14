using API.Models;
using Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class HistoriaClinica
    {
        [Key]
        public int Id { get; set; }

        public int Estado { get; set; }
        public int? IdPaciente { get; set; }
        public int? IdUsuarioCreacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public int? IdUsuarioActualizacion { get; set; }

        // Navigation properties
        [ForeignKey("IdPaciente")]
        public virtual Paciente? Paciente { get; set; }

        [ForeignKey("IdUsuarioCreacion")]
        public virtual User? UsuarioCreacion { get; set; }

        [ForeignKey("IdUsuarioActualizacion")]
        public virtual User? UsuarioActualizacion { get; set; }

        // Colecciones
        public virtual ICollection<SignosFisicos>? SignosFisicos { get; set; }
        public virtual ICollection<MentalPersonal>? MentalPersonal { get; set; }
        public virtual ICollection<HistoriaAcademica>? HistoriaAcademica { get; set; }
        public virtual ICollection<RazonesSintomasConducta>? RazonesSintomasConducta { get; set; }
        public virtual ICollection<DesarrolloPsicosexual>? DesarrolloPsicosexual { get; set; }
        public virtual ICollection<ExamenEstadoMental>? ExamenEstadoMental { get; set; }
        public virtual ICollection<ConceptoPsicologico>? ConceptoPsicologico { get; set; }
    }
}
