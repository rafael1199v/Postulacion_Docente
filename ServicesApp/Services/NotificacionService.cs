public class NotificacionService : INotificacionService
{
    public void EnviarNotificacion(Notificacion notificacion, int DocenteID){

        Console.WriteLine($"Notificacion enviada a Docente con ID: {DocenteID}, Titulo: {notificacion.Titulo}, Descripcion: {notificacion.Descripcion}");
        
    }
 
}
