using Microsoft.AspNetCore.Mvc;
using PostulacionDocente.ServicesApp.Models;
using System;

[ApiController]
[Route("[controller]")]
public class JefeCarreraController : ControllerBase
{
    private readonly IJefeCarreraService _jefeCarreraservice;
    private readonly PostulacionDocenteContext _context;

    // Inyección de dependencias a través del constructor
    public JefeCarreraController(IJefeCarreraService jefeCarreraservice, PostulacionDocenteContext context)
    {
        _jefeCarreraservice = jefeCarreraservice;
        _context = context;
    }

    // [HttpPost("CrearNotificacion")]
    // public IActionResult CrearReunion([FromBody] DateTime fecha)
    // {
    //     try
    //     {
    //         service.CrearReunion(fecha);
    //         return Ok("Reunión creada correctamente.");
    //     }
    //     catch (Exception ex)
    //     {
    //         return BadRequest($"Error al crear la reunión: {ex.Message}");
    //     }
    // }

    [HttpGet("VerSolicitudes")]
    public IActionResult VerSolicitudes()
    {
        try
        {
            var solicitudes = _jefeCarreraservice.ObtenerSolicitudes();
            if (solicitudes.Count == 0)
                return Ok("No hay solicitudes disponibles.");

            return Ok(solicitudes);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error al mostrar las solicitudes: {ex.Message}");
        }
    }

    // [HttpPut("AceptarSolicitud/{nombreSolicitud}")]
    // public IActionResult AceptarSolicitud(string nombreSolicitud)
    // {
    //     try
    //     {
    //         _jefeCarreraservice.AceptarSolicitud(nombreSolicitud);
    //         return Ok($"Solicitud '{nombreSolicitud}' aceptada correctamente.");
    //     }
    //     catch (Exception ex)
    //     {
    //         return BadRequest($"Error al aceptar la solicitud: {ex.Message}");
    //     }
    // }

    [HttpGet("conseguirDatosJefeCarrera/{CI}")]
    public IActionResult ConseguirDatosJefeCarrera(string CI)
    {
        return Ok(_jefeCarreraservice.ConseguirDatosJefeCarrera(_context, CI));
    }


}
