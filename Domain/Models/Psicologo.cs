using Domain.Models;
using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Psicologo: BaseEntity
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public string? Validado { get; set; }
    public string? sugerencias { get; set; }

    public int IdDatosPersonales { get; set; }
    public int? Experiencia { get; set; }
    public string? File_cv { get; set; }
    public virtual DatosPersonale IdDatosPersonalesNavigation { get; set; } = null!;

    public virtual ICollection<PsicologoEspecialidad> PsicologoEspecialidads { get; set; } = new List<PsicologoEspecialidad>();

    public virtual ICollection<PsicologoIdioma> PsicologoIdiomas { get; set; } = new List<PsicologoIdioma>();

    public virtual ICollection<PsicologoServicio> PsicologoServicios { get; set; } = new List<PsicologoServicio>();
}
