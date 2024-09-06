using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("[controller]")]
public class FormularioController : ControllerBase
{
   [HttpPost("guardar")]
    public IActionResult GuardarDatos([FromBody] Formulario formulario){

        IFormularioService IformularioService = new FormularioService();
        IformularioService.GuardarDatos(formulario.postulante, formulario.documentosObligatorios, formulario.documentosOpcionales);

        return Ok();
    }

}