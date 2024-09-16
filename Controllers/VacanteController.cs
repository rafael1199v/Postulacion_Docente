

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
        return _vacanteService.ModificarVacante(vacanteId, new Vacante()) ? Ok() : BadRequest();
    }
}