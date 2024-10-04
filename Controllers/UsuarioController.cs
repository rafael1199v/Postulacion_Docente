using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class UsuarioController: ControllerBase{
    private IUsuarioService service;
    public UsuarioController(IUsuarioService s){
        service = s;
    }

    [HttpPost("registrar")]
    public IActionResult registroUsuario([FromBody] Usuario usuario){

        bool correct;
        string statusMessage = service.registrarUsuario(usuario, out correct);

        return correct? Ok(statusMessage): BadRequest(statusMessage);
    }

    [HttpGet("buscar/{name}")]
    public IActionResult busquedaUsuario(string field, int identifier){
        //identifier funcionará como el tipo de campo que se está buscando
        //0: nombre
        //1: CI
        //2: correo
        //3: numero

        return service.encontrarUsuario(field, identifier)? Ok() : BadRequest();
    }

    [HttpPut("editar")]
    public IActionResult editarDatos((Usuario, Usuario) datos){
        //item 1: Datos antiguos del usuario
        //item 2: Datos actualizados del usuario

        if(service.modificarUsuario(datos.Item1, datos.Item2)){
            return Ok("Usuario actualizado");
        }
        return BadRequest("Hubo un error actualizando los datos");
    }

    [HttpDelete("borrar")]
    public IActionResult destruirUsuario(Usuario objetivo){
        service.eliminarUsuario(objetivo);
        return Ok();
    }
}