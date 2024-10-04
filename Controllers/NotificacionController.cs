using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class NotificacionController : ControllerBase{

    public readonly INotificacionService _notificacionService;

    public NotificacionController(INotificacionService notificacionService)
    {
        _notificacionService = notificacionService;
    }


    [HttpPost("EnviarNotificacion")]
    public IActionResult EnviarNotificacion([FromBody] Notificacion notificacion)
    {
        if (notificacion == null)
        {
            return BadRequest("Notificacion no valida");
        }

        _notificacionService.EnviarNotificacion(notificacion, notificacion.DocenteID);

        return Ok("Notificacion enviada exitosamente");
    }
}
