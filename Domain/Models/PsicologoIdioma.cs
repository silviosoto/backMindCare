using System;
using System.Collections.Generic;

namespace API.Models;

public partial class PsicologoIdioma
{
    public int Id { get; set; }

    public int IdIdioma { get; set; }

    public int? IdPsicologo { get; set; }

    public virtual Idioma ? IdIdiomaNavigation { get; set; } = null!;
    public virtual Psicologo? IdPsicologoNavigation { get; set; } = null!;


}
