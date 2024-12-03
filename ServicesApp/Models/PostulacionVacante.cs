using System;
using System.Collections.Generic;

namespace PostulacionDocente.ServicesApp.Models;

public partial class PostulacionVacante
{
    public int PostulacionVacanteId { get; set; }

    public int VacanteId { get; set; }

    public int PostulacionId { get; set; }
}
