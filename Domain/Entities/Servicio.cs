using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Servicio
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public DateTime FechaInicio { get; set; }

    public DateTime FechaFin { get; set; }

    public bool Estado { get; set; }
}
