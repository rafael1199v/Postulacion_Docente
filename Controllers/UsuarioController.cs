using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class UsuarioController: ControllerBase{
    private IUsuarioService service;
    public UsuarioController(IUsuarioService s){
        service = s;
    }

    [HttpPost("registrar")]
    public IActionResult registroUsuario([FromBody] Usuario nuevoUsuario){

        service.registrarUsuario(nuevoUsuario);

        return Ok();
    }

    [HttpGet("buscar/{name}")]
    public IActionResult busquedaUsuario(string name){

        return service.encontrarUsuario(name)? Ok() : BadRequest();
    }

    [HttpGet("buscar/{name}")]
    public IActionResult busquedaCredenciales(string CI, string correo, string numero){
        List<string> datos = new List<string>{
            CI,correo,numero
        };
        return service.credencialesSinUso(datos)? Ok("Las credenciales están sin uso, puedes utilizarlos") : BadRequest("Credenciales ya en uso");
    }

    [HttpPut("editar")]
    public IActionResult editarDatos(Usuario antiguo){

        // if(service.encontrarUsuario(antiguo)){
        //     service.eliminarUsuario(antiguo);

        //     return Ok();
        // }
        // else{
        //     return BadRequest();
        // }
        return Ok();
    }

    [HttpDelete("borrar")]
    public IActionResult destruirUsuario(Usuario objetivo){
        service.eliminarUsuario(objetivo);
        return Ok();
    }
}