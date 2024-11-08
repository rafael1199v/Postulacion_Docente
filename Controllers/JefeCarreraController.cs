using Microsoft.AspNetCore.Mvc;
using System;

[ApiController]
[Route("[controller]")]
public class JefeCarreraController : ControllerBase
{
    private readonly IJefeCarreraService service;

    // Inyección de dependencias a través del constructor
    public JefeCarreraController(IJefeCarreraService s)
    {
        service = s;
    }

    [HttpPost("CrearNotificacion")]
    public IActionResult CrearReunion([FromBody] DateTime fecha)
    {
        try
        {
            service.CrearReunion(fecha);
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
            var solicitudes = service.ObtenerSolicitudes();
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
            service.AceptarSolicitud(nombreSolicitud);
            return Ok($"Solicitud '{nombreSolicitud}' aceptada correctamente.");
        }
        catch (Exception ex)
        {
            return BadRequest($"Error al aceptar la solicitud: {ex.Message}");
        }
    }

    [HttpGet("DatosPostulante")]
    public IActionResult DatosPostulante([FromBody] Curriculum formulario){
        // try
        // {
        //     string result = service.VerDatosPostulante(formulario);
        //     return Ok(result);
        // }
        // catch (System.Exception ex)
        // {
            
        //     return BadRequest($"Error: {ex.Message}");
        // }
        string result = service.VerDatosPostulante(formulario);
        return Ok(result);
    }

}
