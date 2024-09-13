using Microsoft.AspNetCore.Mvc;
using System;

[ApiController]
[Route("[controller]")]
public class RRHHController : ControllerBase
{
    [HttpGet("Horario")]
    public IActionResult ObtenerHorario()
    {
        IRRHHService _rrhhService = new RRHHService();

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
        IRRHHService _rrhhService = new RRHHService();

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
        IRRHHService _rrhhService = new RRHHService();

        try
        {
            _rrhhService.VerSolicitudes();
            return Ok("Solicitudes mostradas correctamente.");
        }
        catch (Exception ex)
        {
            return BadRequest($"Error al mostrar las solicitudes: {ex.Message}");
        }
    }

    [HttpPut("AceptarSolicitud/{nombreSolicitud}")]
    public IActionResult AceptarSolicitud(string nombreSolicitud)
    {
        IRRHHService _rrhhService = new RRHHService();

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
