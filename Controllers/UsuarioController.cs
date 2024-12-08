using Microsoft.AspNetCore.Mvc;
using PostulacionDocente.ServicesApp.Models;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class UsuarioController: ControllerBase{
    private readonly IUsuarioService _usuarioService;
    private readonly IRegistroService _registroService;
    private readonly PostulacionDocenteContext _context;
    public UsuarioController(IUsuarioService usuarioService, PostulacionDocenteContext context, IRegistroService registroService){
        _usuarioService = usuarioService;
        _context = context;
        _registroService = registroService;
    }

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

    [HttpPost("loginDocente")]
    public IActionResult LoginDocente([FromBody] LoginUsuarioDTO credenciales)
    {
        return _usuarioService.LoginDocente(credenciales, _context, out string mensaje, out string usuarioCI)  ? Ok(new {mensaje, usuarioCI}) : BadRequest(mensaje);
    }

    [HttpPost("loginJefeCarrera")]
    public IActionResult LoginJefeCarrera([FromBody] LoginUsuarioDTO credenciales)
    {
        return _usuarioService.LoginJefeCarrera(credenciales, _context, out string mensaje, out string usuarioCI) ? Ok(new {mensaje, usuarioCI}) : BadRequest(mensaje);
    }

    [HttpPost("registrarDocente")]
    public IActionResult RegistroDocente([FromBody] DocenteRegistroDTO nuevoDocente)
    {
        return _registroService.RegistrarDocente(nuevoDocente, _context, out string mensaje) ? Ok(mensaje) : BadRequest(mensaje);
    }

    [HttpPost("registrarJefeCarrera")]
    public IActionResult RegistroJefeCarrera([FromBody] JefeCarreraRegistroDTO nuevoJefe)
    {
        return _registroService.RegistrarJefeCarrera(nuevoJefe, _context, out string mensaje) ? Ok(mensaje) : BadRequest(mensaje);
    }

    
}