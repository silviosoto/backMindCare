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
    public class ConceptoPsicologico
    {
        [Key]
        public int Id { get; set; }

        public int IdHistoriaClinica { get; set; }
        public string? DiagnosticoPrincipal { get; set; }
        public string? DiagnosticoRelacionado1 { get; set; }
        public string? DiagnosticoRelacionado2 { get; set; }
        public string? PlanDeTratamiento { get; set; }
        public string? Objetivos { get; set; }
        public string? Recomendaciones { get; set; }
        public string? Compromisos { get; set; }
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
