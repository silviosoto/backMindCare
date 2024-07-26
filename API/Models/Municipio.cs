using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Municipio
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int Estado { get; set; }

    public int DepartamentoId { get; set; }
}
