using System;
using System.Collections.Generic;

namespace PostulacionDocente.ServicesApp.Models;

public partial class Postulacion
{
    public int PostulacionId { get; set; }

    public int Estado { get; set; }

    public int DocenteId { get; set; }
}
