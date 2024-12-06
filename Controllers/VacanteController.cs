

using Microsoft.AspNetCore.Mvc;
using PostulacionDocente.ServicesApp.Models;


[ApiController]
[Route("[controller]")]
public class VacanteController : ControllerBase
{
    
    public readonly IVacanteService _vacanteService;
    public readonly PostulacionDocenteContext _context;
    public VacanteController(IVacanteService vacanteService, PostulacionDocenteContext context)
    {
        _vacanteService = vacanteService;
        _context = context;
    }

    [HttpGet("conseguirVacantesDisponibles")]
    public IActionResult ConseguirVacantesDisponibles()
    {
        return Ok(_vacanteService.ConseguirVacantesDisponibles(_context));
    }

    [HttpDelete("eliminarVacante/{vacanteId}")]
    public IActionResult EliminarVacante(int vacanteId)
    {
        return _vacanteService.EliminarVacante(vacanteId, _context) ? Ok() : BadRequest();
    }

    [HttpPut("modificarVacante/{vacanteId}")]
    public IActionResult ModificarVacante(int vacanteId)
    {
        return _vacanteService.ModificarVacante(vacanteId, new VacanteDTO(), _context) ? Ok() : BadRequest();
    }

    //"0001-01-01T00:00:00"
    [HttpPost("crearVacante")]
    public IActionResult CrearVacante([FromBody] VacanteDTO nuevaVacante)
    {
        return _vacanteService.CrearVacante(nuevaVacante, _context) ? Ok("Vacante creada correctamente") : BadRequest("La vacante no se creo correctamente");
    }
}