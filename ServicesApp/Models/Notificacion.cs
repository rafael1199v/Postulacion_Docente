public class Notificacion
{
    public int Id { get; set; }
    public string Mensaje { get; set; }
    public DateTime Fecha { get; set; }
    public string Destinatario { get; set; }

    public Notificacion(int id, string mensaje, DateTime fecha, string destinatario)
    {
        Id = id;
        Mensaje = mensaje;
        Fecha = fecha;
        Destinatario = destinatario;
    }
}
