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
    public class MentalPersonal
    {
        [Key]
        public int Id { get; set; }

        public int IdHistoriaClinica { get; set; }
        public string? DiscapacidadCognitiva { get; set; }
        public string? Epilepsia { get; set; }
        public string? EnfermedadesFamiliaresHeredables { get; set; }
        public string? ConsumoDeSustanciasPsicoactivas { get; set; }
        public string? ConsumoDeAlcohol { get; set; }
        public string? DxDeSaludMental { get; set; }
        public string? IntentoDeSuicidio { get; set; }
        public string? EventosTraumaticos { get; set; }
        public string? SeEncuentraMedicado { get; set; }
        public string? AntecedentesDeAutolesion { get; set; }
        public string? InternacionesEnCentrosPsiquiatricos { get; set; }
        public string? Observaciones { get; set; }
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
