using Microsoft.AspNetCore.Mvc;

namespace PostulacionDocente.Controllers;

[ApiController]
[Route("[controller]")]
public class MateriaController : ControllerBase
{
   [HttpGet("conseguirMaterias")]
    public IActionResult GetMateria(){

        IMateriaService service = new MateriaService();

        return Ok(service.conseguirMaterias());
    }
}