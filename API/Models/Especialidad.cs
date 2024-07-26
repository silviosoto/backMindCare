using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Especialidad
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public string? Validado { get; set; }

    public virtual ICollection<PsicologoEspecialidad> PsicologoEspecialidads { get; set; } = new List<PsicologoEspecialidad>();
}
