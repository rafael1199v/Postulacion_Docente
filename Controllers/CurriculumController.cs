using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("[controller]")]
public class CurriculumController : ControllerBase
{

    private readonly ICurriculumService _curriculumService;

    public CurriculumController(ICurriculumService curriculumService)
    {
        _curriculumService = curriculumService;

    }

   [HttpPost("guardar/docente")]
    public IActionResult GuardarCurriculum([FromBody] Curriculum hoja){

        _curriculumService.GuardarCurriculumDocente(hoja.postulante, hoja.documentos);

        return Ok();
    }

}

