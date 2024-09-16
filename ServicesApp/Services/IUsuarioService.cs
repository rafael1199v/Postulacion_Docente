public interface IUsuarioService
{
    public void registrarUsuario(Usuario usuario);
    public void eliminarUsuario(Usuario usuario);
    public void modificarUsuario(Usuario antiguoUsuario, Usuario datosRenovados);
    public bool encontrarUsuario(string objetivo);
    public bool credencialesSinUso(List<string> datos);
}