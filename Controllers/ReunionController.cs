using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ReunionController : ControllerBase
{
    private readonly IReunionService _reunionService;

    public ReunionController(IReunionService reunionService)
    {
        _reunionService = reunionService;
    }

    [HttpPost("crearReunion")]
    public IActionResult CrearReunion([FromBody] Reunion NuevaReunion)
    {
        if (_reunionService.CrearReunion(NuevaReunion))
        {
            return Ok(new { Mensaje = "Reunión creada con éxito." });
        }
        else
        {
            return BadRequest(new { Mensaje = "Error: La reunión tiene datos incompletos." });
        }
    }
}
