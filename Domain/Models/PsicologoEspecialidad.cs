using System;
using System.Collections.Generic;

namespace API.Models;

public partial class PsicologoEspecialidad
{
    public int Id { get; set; }

    public int? IdPsicologo { get; set; }

    public int? IdEspecialidad { get; set; }

    public string? Validado { get; set; }

    public virtual Especialidad? IdEspecialidadNavigation { get; set; }

    public virtual Psicologo? IdPsicologoNavigation { get; set; }
}
