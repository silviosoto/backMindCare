using Domain.Models;
using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Municipio : BaseEntity
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public bool Estado { get; set; }

    public int DepartamentoId { get; set; }
}
