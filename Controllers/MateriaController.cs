using Microsoft.AspNetCore.Mvc;

namespace PostulacionDocente.Controllers;

[ApiController]
[Route("[controller]")]
public class Materia : ControllerBase
{
   [HttpGet]
    public IActionResult GetMateria(){

        IMateriaService service = new MateriaService();

        return Ok(service.conseguirMaterias());
    }
}