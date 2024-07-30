using Domain.Models;
using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Paciente : BaseEntity
{
    public int Id { get; set; }

    public bool? Estado { get; set; }

    public int? IdDatosPersonales { get; set; }

    public virtual DatosPersonale? IdDatosPersonalesNavigation { get; set; }
}
