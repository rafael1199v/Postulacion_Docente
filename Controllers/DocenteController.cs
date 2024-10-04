using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("[controller]")]
public class DocenteController : ControllerBase
{
    private readonly IDocenteService _docenteService;
    public DocenteController(IDocenteService docenteService)
    {
        _docenteService = docenteService;
    }


   [HttpGet("conseguirDocente/{carnetIdentidad}")]
    public IActionResult conseguirDocente(string carnetIdentidad){
        return Ok(_docenteService.conseguirDocente(carnetIdentidad));
    }

    [HttpGet("VerEstado")]
    public IActionResult VerEstado(int DocenteID, [FromBody] Notificacion notificacion)
    {
        if (notificacion == null)
        {
            return BadRequest("Notifiacion no valida");
        }

        string estado = _docenteService.VerEstado(int DocenteID,int  VacanteID);
        {
            var estado = _docenteService.VerEstado(DocenteID, VacanteID )
        }
        return Ok(estado);
    }

}