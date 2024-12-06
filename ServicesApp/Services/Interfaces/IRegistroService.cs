using PostulacionDocente.ServicesApp.Models;

public interface IRegistroService
{
    public bool RegistrarDocente(DocenteRegistroDTO docente, PostulacionDocenteContext context);
    public bool RegistrarJefeCarrera(JefeCarreraRegistroDTO jefeCarrera, PostulacionDocenteContext context);
    public bool CredencialesEnUsoDocente(DocenteRegistroDTO docente, PostulacionDocenteContext context);
    public bool CredencialesEnUsoJefeCarrera(JefeCarreraRegistroDTO jefeCarrera, PostulacionDocenteContext context);

}