using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("postulaciones")]
public class PostulacionController : ControllerBase
{
    private readonly IPostulacionService _postulacionService;

    public PostulacionController(IPostulacionService postulacionService)
    {
        _postulacionService = postulacionService;
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

}
