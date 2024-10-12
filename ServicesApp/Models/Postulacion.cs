public class Postulacion
{
    public int PostulacionId { get; set; }
    public List<(Formulario, int)> notasDocente { get; set; } = null!;
    public int MateriaId { get; set; }
    public int JefeCarreraId { get; set; }

}