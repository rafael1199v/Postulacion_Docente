using Microsoft.AspNetCore.Mvc;
using PostulacionDocente.ServicesApp.Models;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class UsuarioController: ControllerBase{
    private readonly IUsuarioService _usuarioService;
    private readonly PostulacionDocenteContext _context;
    public UsuarioController(IUsuarioService usuarioService, PostulacionDocenteContext context){
        _usuarioService = usuarioService;
        _context = context;
    }

    // [HttpPost("registrar")]
    // public IActionResult registroUsuario([FromBody] UsuarioDTO usuario){

    //     //bool correct;
    //     string statusMessage = _usuarioService.RegistrarUsuario(usuario);

    //     return Ok(statusMessage);
    // }

    // [HttpGet("buscar/{name}")]
    // public IActionResult busquedaUsuario(string field, int identifier = 1){
    //     //identifier funcionará como el tipo de campo que se está buscando
    //     //0: nombre
    //     //1: CI
    //     //2: correo
    //     //3: numero

    //     return service.EncontrarUsuario(field, identifier)? Ok() : BadRequest();
    // }

    // [HttpPut("editar")]
    // public IActionResult editarDatos((UsuarioDTO, UsuarioDTO) datos){
    //     //item 1: Datos antiguos del usuario
    //     //item 2: Datos actualizados del usuario

    //     if(_usuarioService.ModificarUsuario(datos.Item1, datos.Item2)){
    //         return Ok("Usuario actualizado");
    //     }
    //     return BadRequest("Hubo un error actualizando los datos");
    // }

    [HttpGet("getAll")]
    public IActionResult GetAllUsers()
    {
        var usuarios = from usuario in _context.Usuarios
                        select usuario;
        
        
        return Ok(usuarios);
    }



    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginUsuarioDTO credenciales)
    {
        return _usuarioService.Autenticacion(credenciales, _context) ? Ok("Usuario autenticado") : BadRequest("Hubo un error. Intentalo otra vez");
    }

    
}