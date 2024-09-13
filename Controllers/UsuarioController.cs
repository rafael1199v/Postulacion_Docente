using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class UsuarioController: ControllerBase{
    [HttpPost]
    public IActionResult registroUsuario([FromBody] Usuario nuevoUsuario){

        IUsuarioService _usuarioService = new UsuarioService();
        _usuarioService.registrarUsuario(nuevoUsuario);

        return Ok();
    }
    [HttpGet("Buscar")]
    public IActionResult busquedaUsuario(Usuario buscado){

        IUsuarioService _usuarioService = new UsuarioService();

        return _usuarioService.encontrarUsuario(buscado) ? Ok() : BadRequest();
    }
    [HttpPut]
    public IActionResult editarDatos(Usuario antiguo){
        IUsuarioService _usuarioService = new UsuarioService();

        if(_usuarioService.encontrarUsuario(antiguo)){
            _usuarioService.eliminarUsuario(antiguo);

            return Ok();
        }
        else{
            return BadRequest();
        }
    }
    [HttpDelete]
    public IActionResult destruirUsuario(Usuario objetivo){
        IUsuarioService _usuarioService = new UsuarioService();
        _usuarioService.eliminarUsuario(objetivo);
        return Ok();
    }
}