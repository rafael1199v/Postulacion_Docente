using Microsoft.AspNetCore.Mvc;
using PostulacionDocente.ServicesApp.Models;

[ApiController]
[Route("[controller]")]
public class PostulacionController : ControllerBase
{
    private readonly IPostulacionService _postulacionService;
    private readonly PostulacionDocenteContext _context;

    public PostulacionController(IPostulacionService postulacionService, PostulacionDocenteContext context)
    {
        _postulacionService = postulacionService;
        _context = context;
    }

    [HttpPost("{id}/rechazar")]
    public IActionResult RechazarPostulacion(int id, [FromBody] string razon)
    {
        var resultado = _postulacionService.RechazarPostulacion(id, razon);
        if (resultado.Contains("no encontrada"))
        {
            return NotFound(resultado);
        }
        return Ok(new { Notificacion = resultado });
    }

    [HttpPost("{id}/aceptar")]
    public IActionResult AceptarPostulacion(int id)
    {
        var resultado = _postulacionService.AceptarPostulacion(id);
        if (resultado.Contains("no encontrada"))
        {
            return NotFound(resultado);
        }
        return Ok(new { Notificacion = resultado });
    }

    [HttpGet("ConseguirDetallesPostulacion/{postulacionId}")]
    public IActionResult ConseguirDetallesPostulacion(int postulacionId)
    {
        return Ok(_postulacionService.ConseguirDetallesPostulacion(_context, postulacionId));
    }
    

}
