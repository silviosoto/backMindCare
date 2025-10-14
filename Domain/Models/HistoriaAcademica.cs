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
    public class HistoriaAcademica
    {
        [Key]
        public int Id { get; set; }
        public int IdHistoriaClinica { get; set; }
        public string? EdadDeIngresoALaEscuela { get; set; }
        public string? AdaptacionInicial { get; set; }
        public string? DesempenoAcademico { get; set; }
        public string? AnosPerdidos { get; set; }
        public string? CursoActual { get; set; }
        public string? MateriaQueSeFacilitaYLaQueSeDificulta { get; set; }
        public string? TiempoDiarioDeEstudioHoras { get; set; }
        public int? IdUsuarioCreacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public int? IdUsuarioActualizacion { get; set; }

        // Navigation properties
        [ForeignKey("IdHistoriaClinica")]
        public virtual HistoriaClinica? HistoriaClinica { get; set; }

        [ForeignKey("IdUsuarioCreacion")]
        public virtual User? UsuarioCreacion { get; set; }

        [ForeignKey("IdUsuarioActualizacion")]
        public virtual User? UsuarioActualizacion { get; set; }
    }
}
