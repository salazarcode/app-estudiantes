﻿using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Carrera
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;
}
