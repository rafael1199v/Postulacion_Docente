public class Formulario{
    public Docente? postulante {get;set;}
    public Vacante? vacante {get;set;}
    public List<Documento>? documentosObligatorios {get;set;}
    public List<Documento>? documentosOpcionales {get; set;}
    public int estado {get;set;}
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