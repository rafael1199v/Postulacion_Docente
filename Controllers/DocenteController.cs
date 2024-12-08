using Microsoft.AspNetCore.Mvc;
using PostulacionDocente.ServicesApp.Models;

[ApiController]
[Route("[controller]")]
public class DocenteController : ControllerBase
{
    private readonly IDocenteService _docenteService;
    private readonly PostulacionDocenteContext _context;
    public DocenteController(IDocenteService docenteService, PostulacionDocenteContext context)
    {
        _docenteService = docenteService;
        _context = context;
    }


   [HttpGet("conseguirDocente/{carnetIdentidad}")]
    public IActionResult conseguirDocente(string carnetIdentidad){
        return Ok(_docenteService.conseguirDocente(carnetIdentidad));
    }

    [HttpGet("conseguirDatosDocente/{usuarioCI}")]
    public IActionResult ConseguirDetallesDocente(string usuarioCI)
    {
        return Ok(_docenteService.ConseguirDetallesDocente(_context, usuarioCI));
    }
}