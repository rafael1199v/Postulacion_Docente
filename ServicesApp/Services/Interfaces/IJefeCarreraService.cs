using PostulacionDocente.ServicesApp.Models;

public interface IJefeCarreraService
{
    void CrearReunion(DateTime fecha);
    public void VerSolicitudes();
    void AceptarSolicitud(string nombreSolicitud);
    void RechazarSolicitud(string nombreSolicitud);

    // Nuevos métodos para obtener listas
    List<DocenteDatosPostulacionDTO> ObtenerSolicitudes(PostulacionDocenteContext context, int vacanteId);
    public void VerDatosPostulante();
    public JefeCarreraPerfilDTO? ConseguirDatosJefeCarrera(PostulacionDocenteContext context, string CI);
    public DocenteDatosPostulacionDTO? RevisarPostulacion(PostulacionDocenteContext context, int postulacionId);
}
