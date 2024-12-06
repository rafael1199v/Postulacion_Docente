using PostulacionDocente.ServicesApp.Models;

public class UsuarioService : IUsuarioService
{
    // public bool ModificarUsuario(UsuarioDTO antiguo, UsuarioDTO renovado)
    // {
    //     if (CredencialesSinUso(new List<string> { renovado.CI, renovado.correo, renovado.numero }))
    //     {
    //         antiguo.nombre = renovado.nombre;
    //         antiguo.CI = renovado.CI;
    //         antiguo.contrasenha = renovado.contrasenha;
    //         antiguo.correo = renovado.correo;
    //         //antiguo.fechaNacimiento = renovado.fechaNacimiento;
    //         antiguo.numero = renovado.numero;
    //         System.Console.WriteLine("Usuario modificado");
    //         //enviar antiguo a la base de datos
    //         return true;
    //     }
    //     return false;
    // }

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

  
    public bool LoginDocente(LoginUsuarioDTO credenciales, PostulacionDocenteContext context, out string mensaje)
    {
        mensaje = "Usuario autenticado";

        if (credenciales == null)
        {
            mensaje = "Hubo un error, las credenciales son nulas";
            return false;
        }

        var usuario = (from _usuario in context.Usuarios
                       join _docente in context.Docentes on _usuario.UsuarioId equals _docente.UsuarioId
                       where _usuario.Correo == credenciales.Email && _usuario.Contrasenha == credenciales.Password
                       select _usuario).FirstOrDefault<Usuario>();


        if (usuario == null)
        {
            mensaje = "Credenciales invalidas o el usuario no se encuentra registrado como docente.";
            return false;
        }

        return true;
    }



    public bool LoginJefeCarrera(LoginUsuarioDTO credenciales, PostulacionDocenteContext context, out string mensaje)
    {
        mensaje = "Usuario autenticado";

        if (credenciales == null)
        {
            mensaje = "Hubo un error, las credenciales son nulas";
            return false;
        }

        var usuario = (from _usuario in context.Usuarios
                        join _jefeCarrera in context.JefeCarreras on _usuario.UsuarioId equals _jefeCarrera.UsuarioId
                        where _usuario.Correo == credenciales.Email && _usuario.Contrasenha == credenciales.Password
                        select _usuario).FirstOrDefault<Usuario>();


        if(usuario == null)
        {
            mensaje = "Credenciales invalidas o el usuario no se encuentra registrado como jefe de carrera.";
            return false;
        }


        return true;
    }
}
