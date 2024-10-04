public interface IPostulacionService
{
    public List<(Docente, int)> ConseguirDocentesPonderacionPostulacion(int PostulacionId);
    public List<(Docente, int)> ConseguirMejoresTresNotas(int PostulacionId);
}