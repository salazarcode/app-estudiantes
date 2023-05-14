using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Estudiante
{
    public int Id { get; set; }

    public int CarreraId { get; set; }

    public int TutorId { get; set; }

    public int ServicioId { get; set; }

    public int? UserId { get; set; }

    public virtual Carrera Carrera { get; set; } = null!;

    public virtual Servicio Servicio { get; set; } = null!;

    public virtual Tutor Tutor { get; set; } = null!;

    public virtual Usuario? User { get; set; }
}
