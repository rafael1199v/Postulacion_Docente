using Microsoft.AspNetCore.Mvc;
using System;

[ApiController]
[Route("[controller]")]
public class JefeCarreraController : ControllerBase
{
    private readonly IJefeCarreraService _rrhhService;

    // Inyección de dependencias a través del constructor
    public JefeCarreraController(IJefeCarreraService rrhhService)
    {
        _rrhhService = rrhhService;
    }

    [HttpGet("Horario")]
    public IActionResult ObtenerHorario()
    {
        try
        {
            _rrhhService.Horario();
            return Ok("Horario mostrado correctamente.");
        }
        catch (Exception ex)
        {
            return BadRequest($"Error al mostrar el horario: {ex.Message}");
        }
    }

    [HttpPost("CrearReunion")]
    public IActionResult CrearReunion([FromBody] DateTime fecha)
    {
        try
        {
            _rrhhService.CrearReunion(fecha);
            return Ok("Reunión creada correctamente.");
        }
        catch (Exception ex)
        {
            return BadRequest($"Error al crear la reunión: {ex.Message}");
        }
    }

    [HttpGet("VerSolicitudes")]
    public IActionResult VerSolicitudes()
    {
        try
        {
            var solicitudes = _rrhhService.ObtenerSolicitudes();
            if (solicitudes.Count == 0)
                return Ok("No hay solicitudes disponibles.");

            return Ok(solicitudes);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error al mostrar las solicitudes: {ex.Message}");
        }
    }

    [HttpPut("AceptarSolicitud/{nombreSolicitud}")]
    public IActionResult AceptarSolicitud(string nombreSolicitud)
    {
        try
        {
            _rrhhService.AceptarSolicitud(nombreSolicitud);
            return Ok($"Solicitud '{nombreSolicitud}' aceptada correctamente.");
        }
        catch (Exception ex)
        {
            return BadRequest($"Error al aceptar la solicitud: {ex.Message}");
        }
    }

    // Acción adicional para obtener las reuniones
    [HttpGet("VerReuniones")]
    public IActionResult VerReuniones()
    {
        try
        {
            var reuniones = _rrhhService.ObtenerReuniones();
            if (reuniones.Count == 0)
                return Ok("No hay reuniones programadas.");

            return Ok(reuniones);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error al mostrar las reuniones: {ex.Message}");
        }
    }
}
