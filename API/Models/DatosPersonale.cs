using System;
using System.Collections.Generic;

namespace API.Models;

public partial class DatosPersonale
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellidos { get; set; }

    public string? FechaNacimiento { get; set; }

    public string? Email { get; set; }

    public string? Telefono { get; set; }

    public string? TipoId { get; set; }

    public string? NumeroId { get; set; }

    public int? MunicipiosId { get; set; }

    public virtual ICollection<Paciente>? Pacientes { get; set; } = new List<Paciente>();

    public virtual ICollection<Psicologo>? Psicologos { get; set; } = new List<Psicologo>();
}
