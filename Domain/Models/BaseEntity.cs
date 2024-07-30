

namespace Domain.Models
{
    public abstract class BaseEntity
    {
        public bool? Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
    }
}
