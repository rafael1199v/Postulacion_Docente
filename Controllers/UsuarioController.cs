using Microsoft.AspNetCore.Mvc;
using PostulacionDocente.ServicesApp.Models;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class UsuarioController: ControllerBase{
    private readonly IUsuarioService service;
    private readonly PostulacionDocenteContext _context;
    public UsuarioController(IUsuarioService s, PostulacionDocenteContext context){
        service = s;
        _context = context;
    }

    [HttpPost("registrar")]
    public IActionResult registroUsuario([FromBody] UsuarioDTO usuario){

        //bool correct;
        string statusMessage = service.registrarUsuario(usuario);

        return Ok(statusMessage);
    }

    [HttpGet("buscar/{name}")]
    public IActionResult busquedaUsuario(string field, int identifier = 1){
        //identifier funcionará como el tipo de campo que se está buscando
        //0: nombre
        //1: CI
        //2: correo
        //3: numero

        return service.encontrarUsuario(field, identifier)? Ok() : BadRequest();
    }

    [HttpPut("editar")]
    public IActionResult editarDatos((UsuarioDTO, UsuarioDTO) datos){
        //item 1: Datos antiguos del usuario
        //item 2: Datos actualizados del usuario

        if(service.modificarUsuario(datos.Item1, datos.Item2)){
            return Ok("Usuario actualizado");
        }
        return BadRequest("Hubo un error actualizando los datos");
    }

    [HttpDelete("borrar")]
    public IActionResult destruirUsuario(UsuarioDTO objetivo){
        service.eliminarUsuario(objetivo);
        return Ok();
    }

    [HttpPost("login")]
    public IActionResult login([FromBody] LoginUsuarioDTO loginUsuario)
    {
        Console.WriteLine(loginUsuario.Email);
        System.Console.WriteLine(loginUsuario.Password);


        return Ok();
    }


    [HttpGet("getAll")]
    public IActionResult GetAllUsers()
    {
        var usuarios = from usuario in _context.Usuario
                        select usuario;
        
        
        return Ok(usuarios);
    }

    
}