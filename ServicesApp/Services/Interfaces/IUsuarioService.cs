using PostulacionDocente.ServicesApp.Models;

public interface IUsuarioService
{
    //public bool ModificarUsuario(UsuarioDTO antiguo, UsuarioDTO renovado);
    //public bool CredencialesSinUso(List<string> datos);
    public bool LoginDocente(LoginUsuarioDTO credenciales, PostulacionDocenteContext context, out string mensaje, out string usuarioCI);
    public bool LoginJefeCarrera(LoginUsuarioDTO credenciales, PostulacionDocenteContext context, out string mensaje, out string usuarioCI);
}