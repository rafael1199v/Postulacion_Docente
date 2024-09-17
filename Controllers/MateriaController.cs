using Microsoft.AspNetCore.Mvc;

namespace PostulacionDocente.Controllers;

[ApiController]
[Route("[controller]")]
public class MateriaController : ControllerBase
{
    private readonly IMateriaService _materiaService;

    public MateriaController(IMateriaService materiaService)
    {
        _materiaService = materiaService;
    }

   [HttpGet("conseguirMaterias")]
    public IActionResult GetMateria(){

        IMateriaService service = new MateriaService();

        return Ok(service.conseguirMaterias());
    }
}