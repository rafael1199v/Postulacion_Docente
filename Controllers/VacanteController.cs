

using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("[controller]")]
public class VacanteController : ControllerBase
{
    
    public readonly IVacanteService _vacanteService;

    public VacanteController(IVacanteService vacanteService)
    {
        _vacanteService = vacanteService;
    }

    [HttpGet("conseguirVacantes")]
    public IActionResult ConseguirVacantesDisponibles()
    {
        return Ok(_vacanteService.ConseguirVacantesDisponibles());
    }

    [HttpDelete("eliminarVacante/{vacanteId}")]
    public IActionResult EliminarVacante(int vacanteId)
    {
        return _vacanteService.EliminarVacante(vacanteId) ? Ok() : BadRequest();
    }

    [HttpPut("modificarVacante/{vacanteId}")]
    public IActionResult ModificarVacante(int vacanteId)
    {
        return _vacanteService.ModificarVacante(vacanteId, new VacanteDTO()) ? Ok() : BadRequest();
    }

    //"0001-01-01T00:00:00"
    [HttpPost("crearVacante")]
    public IActionResult CrearVacante([FromBody] VacanteDTO nuevaVacante)
    {
        return _vacanteService.CrearVacante(nuevaVacante) ? Ok("Vacante creada correctamente") : BadRequest("La vacante no se creo correctamente");
    }
}