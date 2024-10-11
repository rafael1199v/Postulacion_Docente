public interface IJefeCarreraService
{
    void CrearReunion(DateTime fecha);
    public void VerSolicitudes();
    void AceptarSolicitud(string nombreSolicitud);

    // Nuevos métodos para obtener listas
    List<(string Nombre, string Curso)> ObtenerSolicitudes();
}