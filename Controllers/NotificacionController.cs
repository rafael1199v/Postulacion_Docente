using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class NotificacionController : ControllerBase
{
    private readonly INotificacionService _notificacionService;

    public NotificacionController(INotificacionService notificacionService)
    {
        _notificacionService = notificacionService;
    }

    [HttpPost("enviar")]
    public IActionResult EnviarNotificacion([FromBody] Notificacion notificacion)
    {
        _notificacionService.EnviarNotificacion(notificacion);
        return Ok("Notificación enviada con éxito.");
    }

    [HttpGet("obtener/{destinatario}")]
    public IActionResult ObtenerNotificaciones(string destinatario)
    {
        var notificaciones = _notificacionService.ObtenerNotificaciones(destinatario);
        return Ok(notificaciones);
    }
}
