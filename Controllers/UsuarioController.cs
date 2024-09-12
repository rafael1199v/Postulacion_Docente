using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpPost]
    public IActionResult registroUsuario([FromBody] Usuario nuevoUsuario)
    {
        _usuarioService.registrarUsuario(nuevoUsuario);
        return Ok();
    }

    [HttpGet]
    public IActionResult busquedaUsuario([FromQuery] Usuario buscado)
    {
        return _usuarioService.encontrarUsuario(buscado) ? Ok() : BadRequest();
    }

    [HttpPut]
    public IActionResult editarDatos([FromBody] Usuario renovado, [FromQuery] Usuario antiguo)
    {
        if (_usuarioService.encontrarUsuario(antiguo))
        {
            _usuarioService.eliminarUsuario(antiguo);
            _usuarioService.registrarUsuario(renovado);
            return Ok();
        }
        else
        {
            return BadRequest();
        }
    }

    [HttpDelete]
    public IActionResult destruirUsuario([FromQuery] Usuario objetivo)
    {
        _usuarioService.eliminarUsuario(objetivo);
        return Ok();
    }
}
