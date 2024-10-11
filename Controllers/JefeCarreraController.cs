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

    [HttpPost("CrearNotificacion")]
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

}
