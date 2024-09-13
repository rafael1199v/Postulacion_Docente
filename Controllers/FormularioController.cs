using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("[controller]")]
public class FormularioController : ControllerBase
{
   [HttpPost("guardar/docente")]
    public IActionResult GuardarDatosFormularioDocente([FromBody] Formulario formulario){

        IFormularioService IformularioService = new FormularioService();
        IformularioService.GuardarDatosFormularioDocente(formulario.postulante, formulario.documentosObligatorios, formulario.documentosOpcionales);

        return Ok();
    }

}

