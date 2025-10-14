 
using Data.Models;  
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 

namespace Domain.Models
{
    public class SignosFisicos
    {
        [Key]
        public int Id { get; set; }

        public int IdHistoriaClinica { get; set; }
        public string? Laceraciones { get; set; }
        public string? Hematoma { get; set; }
        public string? Quemaduras { get; set; }
        public string? Cicatrices { get; set; }
        public string? Fracturas { get; set; }
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
