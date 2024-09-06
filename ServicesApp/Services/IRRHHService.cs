public interface IRRHHService
{
    void Horario();
    void CrearReunion(DateTime fecha);
    void VerSolicitudes();
    void AceptarSolicitud(string nombreSolicitud);
}
