using API.Models;
using Domain.Models;
using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool Estado { get; set; }

    public int IdDatosPersonales { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }
    public int idPerfil { get; set; }
    public virtual DatosPersonale IdDatosPersonalesNavigation { get; set; } = null!;
    public virtual Hobbies Hobbies { get; set; }

}
