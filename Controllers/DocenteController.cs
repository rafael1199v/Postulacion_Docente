using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("[controller]")]
public class DocenteController : ControllerBase
{
   [HttpGet("conseguirDocente")]
    public IActionResult conseguirDocente(int usuarioId){

        IDocenteService IdocenteService = new DocenteService();
        return Ok(IdocenteService.conseguirDocente(usuarioId));
    }

}