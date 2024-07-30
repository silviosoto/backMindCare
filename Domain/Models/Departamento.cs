using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public partial class Departamento : BaseEntity
{
    [Key]
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;
}
