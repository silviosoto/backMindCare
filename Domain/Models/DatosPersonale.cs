using Data.Models;
using Domain.Models;

namespace API.Models;

public partial class DatosPersonale : BaseEntity
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellidos { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public string? Email { get; set; }

    public string? Telefono { get; set; }

    public string? TipoId { get; set; }

    public string? NumeroId { get; set; }

    public int? MunicipiosId { get; set; }

    public Paciente Paciente { get; set; }
    public string? ImagePerfil { get; set; }

    public virtual ICollection<Psicologo>? Psicologos { get; set; } = new List<Psicologo>();
    public virtual User User { get; set; } = null!;
    public virtual Hobbies Hobbies { get; set; } = null!;


}
