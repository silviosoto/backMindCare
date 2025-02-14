using Domain.Models;
using System;
using System.Collections.Generic;

namespace API.Models;

public partial class PsicologoServicio: BaseEntity
{
    public int Id { get; set; }

    public int IdServicio { get; set; }

    public int IdPsicologo { get; set; }
    public decimal Valor { get; set; }
    public bool? Estado { get; set; }
    public virtual Psicologo? IdPsicologoNavigation { get; set; } = null!;

    public virtual Servicio? IdServicioNavigation { get; set; } = null!;
}
