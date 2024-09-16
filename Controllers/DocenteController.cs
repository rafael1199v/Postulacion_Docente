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

}