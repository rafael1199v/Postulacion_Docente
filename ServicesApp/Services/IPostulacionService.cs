public interface IPostulacionService
{
    public List<NotaDocente> ConseguirDocentesPonderacionPostulacion(int PostulacionId);
    public List<NotaDocente> ConseguirMejoresTresNotas(int PostulacionId);

}