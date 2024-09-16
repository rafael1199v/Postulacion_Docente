


using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("[controller]")]

public class PostulacionController : ControllerBase
{
    public readonly IPostulanteService _postulanteService;

    public PostulacionController(IPostulanteService postulanteService)
    {
        _postulanteService = postulanteService;
    }


    [HttpPost("registrarPostulante/{postulanteId}/{vacanteId}")]
    public IActionResult RegistrarPostulante(int postulanteId, int vacanteId){
        return _postulanteService.RegistrarPostulante(postulanteId, vacanteId) ? Ok() : BadRequest();
    }

    [HttpDelete("eliminarPostulante/{postulanteId}/{vacanteId}")]
    public IActionResult EliminarPostulante(int postulanteId, int vacanteId)
    {
        return _postulanteService.EliminarPostulacion(postulanteId, vacanteId) ? Ok() : BadRequest();
    }
}