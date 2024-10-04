public class PostulacionService : IPostulacionService
{

    public List<(Docente, int)> ConseguirDocentesPonderacionPostulacion(int PostulacionId)
    {
        List<(Docente, int)> notasDocente = new List<(Docente, int)>();

        notasDocente.Add((new Docente(), 100));
        notasDocente.Add((new Docente(), 20));
        notasDocente.Add((new Docente(), 10));

        return notasDocente;
    }
    public List<(Docente, int)> ConseguirMejoresTresNotas(int PostulacionId)
    {
        var notasDocente = ConseguirDocentesPonderacionPostulacion(PostulacionId);

        notasDocente.Sort((x, y) => y.Item2.CompareTo(x.Item2));

        return notasDocente;
    }

}