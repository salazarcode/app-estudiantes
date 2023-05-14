using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Tutor
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Ci { get; set; }
}
