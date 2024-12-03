public class VacanteDTO
{
    public string? NombreVacante { get; set; } = string.Empty;
    public string? Materia { get; set; }
    public string? DescripcionVacante { get; set; } = string.Empty;
    public List<PostulacionDTO>? Postulaciones {get;set;}
    public DateTime FechaInicion {get; set;}
    public DateTime FechaFinalizacion {get; set;}
}