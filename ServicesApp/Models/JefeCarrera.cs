﻿using System;
using System.Collections.Generic;

namespace PostulacionDocente.ServicesApp.Models;

public partial class JefeCarrera
{
    public int JefeCarreraId { get; set; }

    public int UsuarioId { get; set; }

    public int CarreraId { get; set; }
}
