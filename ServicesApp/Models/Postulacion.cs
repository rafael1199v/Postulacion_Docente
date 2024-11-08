public class Postulacion
{
    public int PostulacionId { get; set; }
    public int MateriaId { get; set; }
    public int JefeCarreraId { get; set; }
    public string Estado {get;set;}

    /*
    Los estados son:
    -1: Rechazado
     1: Enviado y por ser revisado
     2: 2da fase, exposición y puntuación
     3: 3ra fase, entrevista final
     4: Aceptada, el postulante ya es contratado
     0: Borrado?
    */
}