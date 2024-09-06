using Microsoft.AspNetCore.Mvc;



[ApiController]
[Route("[controller]")]
public class DocenteController : ControllerBase
{
   [HttpPost("guardar")]
    public IActionResult GuardarDatos([FromBody] List<Documento> documentosObligatorios, [FromBody] List<Documento> documentosOpcionales, [FromBody] Docente nuevoDocente){

        IFormularioService IformularioService = new FormularioService();

        IformularioService.GuardarDatos(nuevoDocente, documentosObligatorios, documentosOpcionales);

        return Ok();
    }

}