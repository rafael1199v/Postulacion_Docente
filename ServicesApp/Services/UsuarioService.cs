using PostulacionDocente.ServicesApp.Models;

public class UsuarioService : IUsuarioService
{
    public string RegistrarUsuario(UsuarioDTO usuario)
    {
        if (CredencialesSinUso(new List<string> { usuario.CI, usuario.correo, usuario.numero }))
        {
            UsuarioDTO newUsuario = usuario;
            //enviar "newUsuario a la base de datos"

            return $"Nuevo usuario creado: {newUsuario.nombre}!";
        }
        else
        {
            //debería haber una forma de conservar la hoja de vida de datos para evitar escribir todo de nuevo

            return "No se pudo crear el nuevo usuario... Credenciales ya en uso";
        }
    }

    public bool ModificarUsuario(UsuarioDTO antiguo, UsuarioDTO renovado)
    {
        if (CredencialesSinUso(new List<string> { renovado.CI, renovado.correo, renovado.numero }))
        {
            antiguo.nombre = renovado.nombre;
            antiguo.CI = renovado.CI;
            antiguo.contrasenha = renovado.contrasenha;
            antiguo.correo = renovado.correo;
            //antiguo.fechaNacimiento = renovado.fechaNacimiento;
            antiguo.numero = renovado.numero;
            System.Console.WriteLine("Usuario modificado");
            //enviar antiguo a la base de datos
            return true;
        }
        return false;
    }

    // public bool EncontrarUsuario(string objetivo, int tipo){
    //identifier funcionará como el tipo de campo que se está buscando
    //0: nombre
    //1: CI
    //2: correo
    //3: numero

    //     List<UsuarioDTO> lista = new List<UsuarioDTO>{
    //         new UsuarioDTO{nombre = "Daniel"}
    //     };

    //     for(int i = 0; i < lista.Count; i++){
    //         switch (tipo)
    //         {
    //             case 0:
    //                 if(objetivo == lista[i].nombre){
    //                     return true;
    //                 }
    //                 break;
    //             case 1:
    //                 if(objetivo == lista[i].CI){
    //                     return true;
    //                 }
    //                 break;
    //             case 2:
    //                 if(objetivo == lista[i].correo){
    //                     return true;
    //                 }
    //                 break;
    //             case 3:
    //                 if(objetivo == lista[i].numero){
    //                     return true;
    //                 }
    //                 break;

    //             default:
    //                 System.Console.WriteLine("XD");
    //                 break;
    //         }
    //     }
    //     return false;
    //     //TODO: Rehacer esta búsqueda toda fea
    // }

    public bool CredencialesSinUso(List<string> datos)
    {
        List<UsuarioDTO> lista = new List<UsuarioDTO>{
            new UsuarioDTO{nombre = "Daniel", CI = "10990989", correo = "eldanielitu@gmail.com", numero = "68829531"}
        };
        /*
        lista[0] == CI
        lista[1] == correo
        lista[2] == numero (o sea, telefono)
        */
        for (int i = 0; i < lista.Count; i++)
        {
            if (lista[i].CI == datos[0] || lista[i].correo == datos[1] || lista[i].numero == datos[2])
            {
                return false;
            } //si encuentra similitud, retorna falso, diciendo que las credenciales NO están "sin usar" xd
        } //TODO: Rehacer esta cosa también xd
        return true;
    }


    public bool Autenticacion(LoginUsuarioDTO credenciales, PostulacionDocenteContext context)
    {

        if (credenciales == null) return false;

        var usuario = (from _usuario in context.Usuario
                       where _usuario.Correo == credenciales.Email && _usuario.Contrasenha == credenciales.Password
                       select _usuario).FirstOrDefault<Usuario>();


        if (usuario == null) return false;


        return true;
    }
}
