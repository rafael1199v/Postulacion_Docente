public class Postulacion
{
    public int PostulacionId { get; set; }
    public List<(Docente Docente, int Nota)> NotasDocente { get; set; } = new List<(Docente, int)>();
    public int MateriaId { get; set; }
    public int JefeCarreraId { get; set; }
    public string? Estado { get; set; }
}