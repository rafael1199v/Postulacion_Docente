public interface IUsuarioService
{
    public string registrarUsuario(UsuarioDTO usuario);
    public void eliminarUsuario(UsuarioDTO usuario);
    public bool modificarUsuario(UsuarioDTO antiguo, UsuarioDTO renovado);
    public bool encontrarUsuario(string objetivo, int tipo);
    public bool credencialesSinUso(List<string> datos);
}