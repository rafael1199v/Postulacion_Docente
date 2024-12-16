using PostulacionDocente.ServicesApp.Models;
public class VacantePendienteDTO
{
    public int VacanteId { get; set; }
    public string? NombreVacante { get; set; } = string.Empty;
    public string? Materia { get; set; }
    public string? DescripcionVacante { get; set; } = string.Empty;
    public DateTime FechaInicio {get; set;}
    public DateTime FechaFinalizacion {get; set;}
    public JefeCarrera jefeCarrera {get;set;}
    public Materium materia {get;set;}

}