public class PostulacionService : IPostulacionService
{

    public List<NotaDocente> ConseguirDocentesPonderacionPostulacion(int PostulacionId)
    {
        List<NotaDocente> notasDocente = new List<NotaDocente>(){
            new NotaDocente{Docente = new Docente(), Nota = 50},
            new NotaDocente{Docente = new Docente(), Nota = 100},
            new NotaDocente{Docente = new Docente(), Nota = 20},
            new NotaDocente{Docente = new Docente(), Nota = 90},
            new NotaDocente{Docente = new Docente(), Nota = 75},

        };

      

        return notasDocente;
    }
    public List<NotaDocente> ConseguirMejoresTresNotas(int PostulacionId)
    {
        var docente = ConseguirDocentesPonderacionPostulacion(PostulacionId);
        docente.Sort((x, y) => -x.Nota.CompareTo(y.Nota));

        List<NotaDocente> mejoresDocentes = new List<NotaDocente>();

        for(int i = 0; i < 3; i++)
        {
            mejoresDocentes.Add(docente[i]);
        }
        return mejoresDocentes;
    }

}