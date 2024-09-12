using Microsoft.AspNetCore.Mvc;
using System;

[ApiController]
[Route("[controller]")]
public class RRHHController : ControllerBase
{
    private readonly IRRHHService _rrhhService;

    public RRHHController(IRRHHService rrhhService)
    {
        _rrhhService = rrhhService;
    }

    // GET
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

    // POST
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

    // GET
    [HttpGet("VerSolicitudes")]
    public IActionResult VerSolicitudes()
    {
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

    // PUT
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
