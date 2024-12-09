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

    
    [HttpGet("verSolitciudes/{vacanteId}")]
    public IActionResult VerSolicitudes(int vacanteId)
    {
       return Ok(_jefeCarreraservice.ObtenerSolicitudes(_context, vacanteId)); 
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


    [HttpGet("revisarPostulacion/{postulacionId}")]
    public IActionResult RevisarPostulacion(int postulacionId)
    {
        return Ok(_jefeCarreraservice.RevisarPostulacion(_context, postulacionId));
    }


}
