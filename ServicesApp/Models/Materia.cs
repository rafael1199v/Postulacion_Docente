using System;
using System.Collections.Generic;

namespace PostulacionDocente.ServicesApp.Models;

public partial class Materia
{
    public int MateriaId { get; set; }

    public string NombreMateria { get; set; } = null!;

    public string Sigla { get; set; } = null!;
}
