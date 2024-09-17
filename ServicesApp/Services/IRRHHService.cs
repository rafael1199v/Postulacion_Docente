public interface IRRHHService
{
    void Horario();
    void CrearReunion(DateTime fecha);
    void VerSolicitudes();
    void AceptarSolicitud(string nombreSolicitud);

    // Nuevos métodos para obtener listas
    List<(string Nombre, string Curso)> ObtenerSolicitudes();
    List<DateTime> ObtenerReuniones();
}
