public interface INotificacionService
{
    void EnviarNotificacion(Notificacion notificacion);
    List<Notificacion> ObtenerNotificaciones(string destinatario);
}
