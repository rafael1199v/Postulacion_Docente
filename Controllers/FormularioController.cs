using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("[controller]")]
public class FormularioController : ControllerBase
{

    private readonly IFormularioService _formularioService;

    public FormularioController(IFormularioService formularioService)
    {
        _formularioService = formularioService;

    }

   [HttpPost("guardar/docente")]
    public IActionResult GuardarDatosFormularioDocente([FromBody] Curriculum formulario){

        _formularioService.GuardarDatosFormularioDocente(formulario.postulante, formulario.documentos);

        return Ok();
    }

}

