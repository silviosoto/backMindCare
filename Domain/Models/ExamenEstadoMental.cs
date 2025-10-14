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
    public class ExamenEstadoMental
    {
        [Key]
        public int Id { get; set; }
        public int IdHistoriaClinica { get; set; }
        public string? NivelDeConciencia { get; set; }
        public string? Atencion { get; set; }
        public string? Sensopercepcion { get; set; }
        public string? Afecto { get; set; }
        public string? Lenguaje { get; set; }
        public string? Orientacion { get; set; }
        public string? Sueno { get; set; }
        public string? Pensamiento { get; set; }
        public string? ConductaMotora { get; set; }
        public string? Memoria { get; set; }
        public string? PatronDeAlimentacion { get; set; }
        public string? Inteligencia { get; set; }
        public string? NivelDeRazonamiento { get; set; }
        public string? PorteYActitud { get; set; }
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
