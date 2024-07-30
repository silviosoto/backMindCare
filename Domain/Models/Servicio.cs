using Domain.Models;
using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Servicio : BaseEntity
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<PsicologoServicio>? PsicologoServicios { get; set; } = new List<PsicologoServicio>();
}
