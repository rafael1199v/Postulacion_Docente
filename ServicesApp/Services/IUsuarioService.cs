public interface IUsuarioService
{
    public void registrarUsuario(Usuario usuario);
    public void eliminarUsuario(Usuario usuario);
    public bool modificarUsuario(Usuario antiguo, Usuario renovado);
    public bool encontrarUsuario(string objetivo, int tipo);
    public bool credencialesSinUso(List<string> datos);
}