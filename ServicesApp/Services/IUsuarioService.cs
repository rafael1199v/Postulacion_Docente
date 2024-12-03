using PostulacionDocente.ServicesApp.Models;

public interface IUsuarioService
{
    public string RegistrarUsuario(UsuarioDTO usuario);
    public bool ModificarUsuario(UsuarioDTO antiguo, UsuarioDTO renovado);
    public bool CredencialesSinUso(List<string> datos);
    public bool Autenticacion(LoginUsuarioDTO credenciales, PostulacionDocenteContext context);
}