public class Reunion
{
    public int Id { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public DateTime Fecha { get; set; }
    public TimeSpan Hora { get; set; }
    public string Lugar { get; set; } = string.Empty;
    public List<string> Participantes { get; set; } = new List<string>();
    public TimeSpan Duracion { get; set; }
    public string TipoReunion { get; set; } = string.Empty;
}
