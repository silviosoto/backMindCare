using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Paciente
{
    public int Id { get; set; }

    public string? Estado { get; set; }

    public int? IdDatosPersonales { get; set; }

    public virtual DatosPersonale? IdDatosPersonalesNavigation { get; set; }
}
