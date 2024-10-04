public class Vacante
{

    public int VacanteID {get; set;}
    public string NombreVacante { get; set; } = string.Empty;
    public Materia Materia { get; set; } = null!;
    public string DescripcionVacante { get; set; } = string.Empty;
    public bool VacanteDisponible { get; set; }

}