using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class Perfil
{
    public int Id { get; set; }

    public string nombre { get; set; } = null!; 

    public bool Estado { get; set; } 
    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; } 

}
