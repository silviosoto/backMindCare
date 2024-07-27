using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Servicio
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public bool? Estado { get; set; }

    public virtual ICollection<PsicologoServicio>? PsicologoServicios { get; set; } = new List<PsicologoServicio>();
}
