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

    public bool encontrarUsuario(string objetivo){

        List<Usuario> lista = new List<Usuario>{
            new Usuario{nombre = "Daniel"}
        };
        for(int i = 0; i < lista.Count; i++){
            if(objetivo == lista[i].nombre){
                return true;
            }
        }
        return false;
        //TODO: Rehacer esta búsqueda toda fea
    }
    
    public bool credencialesSinUso(List<string> datos){
        List<Usuario> lista = new List<Usuario>{
            new Usuario{nombre = "Daniel", CI = "10990989", correo = "eldanielitu@gmail.com", numero = "68829531"}
        };
        /*
        lista[0] == CI
        lista[1] == correo
        lista[2] == numero (o sea, telefono)
        */
        for(int i = 0; i < lista.Count; i++){
            if(lista[i].CI == datos[0] || lista[i].correo == datos[1] || lista[i].numero == datos[2]){
                return false;
            } //si encuentra similitud, retorna falso, diciendo que las credenciales NO están "sin usar" xd
        } //TODO: Rehacer esta cosa también xd
        return true;
    }
}
