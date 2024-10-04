


using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("[controller]")]

public class PostulacionController : ControllerBase
{
    public readonly IPostulanteService _postulanteService;
    public readonly IPostulacionService _postulacionService;

    public PostulacionController(IPostulanteService postulanteService, IPostulacionService postulacionService)
    {
        _postulanteService = postulanteService;
        _postulacionService = postulacionService;
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

    [HttpGet("conseguirMejoresNotas/{postulacionId}")]
    public IActionResult ConseguirMejoresTresDocentes(int postulacionId)
    {
        return Ok(_postulacionService.ConseguirMejoresTresNotas(postulacionId));
    }

}
        