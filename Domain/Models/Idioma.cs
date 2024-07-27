using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Idioma
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public bool? Estado { get; set; }

    public virtual ICollection<PsicologoIdioma>? PsicologoIdiomas { get; set; } = new List<PsicologoIdioma>();
}
