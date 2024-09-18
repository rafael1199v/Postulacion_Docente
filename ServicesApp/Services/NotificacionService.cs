public class NotificacionService : INotificacionService
{
    private List<Notificacion> _notificaciones = new List<Notificacion>();

    public void EnviarNotificacion(Notificacion notificacion)
    {
        _notificaciones.Add(notificacion);
        Console.WriteLine($"Notificación enviada a {notificacion.Destinatario}: {notificacion.Mensaje}");
    }

    public List<Notificacion> ObtenerNotificaciones(string destinatario)
    {
        return _notificaciones.Where(n => n.Destinatario == destinatario).ToList();
    }
}
