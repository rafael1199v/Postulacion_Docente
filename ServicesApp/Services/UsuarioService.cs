using Microsoft.VisualBasic;

public class UsuarioService : IUsuarioService
{

    public void registrarUsuario(Usuario usuario)
    {
        System.Console.WriteLine("Registro de usuario");
    }

    public void eliminarUsuario(Usuario usuario)
    {
        System.Console.WriteLine("Usuario eliminado");
    }

    public void modificarUsuario(Usuario antiguoUsuario, Usuario datosRenovados)
    {
        System.Console.WriteLine("Usuario modificado");
    }

    public bool encontrarUsuario(Usuario objetivo){
        //return (objetivo in appdbcontext) ? true : false;
        return true;
    }


}
