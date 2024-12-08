using Microsoft.EntityFrameworkCore;
using PostulacionDocente.ServicesApp.Models;

public class UsuarioService : IUsuarioService
{
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

  
    public bool LoginDocente(LoginUsuarioDTO credenciales, PostulacionDocenteContext context, out string mensaje, out string usuarioCI)
    {
        mensaje = "Usuario autenticado";
        usuarioCI = "-1";

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

        usuarioCI = usuario.Ci;
        return true;
    }



    public bool LoginJefeCarrera(LoginUsuarioDTO credenciales, PostulacionDocenteContext context, out string mensaje, out string usuarioCI)
    {
        mensaje = "Usuario autenticado";
        usuarioCI= "-1";
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

        usuarioCI= usuario.Ci;
        return true;
    }


    public bool CambiarDatosDocente(DocenteNuevosDatosDTO nuevosDatosDocente, PostulacionDocenteContext context, out string mensaje)
    {
        mensaje = "Datos modificados exitosamente";

        var docente = (from _docente in context.Docentes
                      join _usuario in context.Usuarios on _docente.UsuarioId equals _usuario.UsuarioId
                      where _usuario.Ci == nuevosDatosDocente.CI
                      select _docente).Include(d => d.Usuario).FirstOrDefault<Docente>();

        if(docente == null)
        {
            mensaje = "Hubo un error, no pudimos encontrar al usuario";
            return false;
        }
        else if(docente.Usuario.Contrasenha != nuevosDatosDocente.ContrasenhaActual)
        {
            mensaje = "La contrasenha actual del usuario es incorrecta";
            return false;
        }
        
        //Si el docente quiere mantener su numero de telefono o su correo, solo se agarra los numeros y correos diferentes al del docente
        HashSet<string> telefonos = context.Usuarios.Select(usuario => usuario.NumeroTelefono).Where(telefono => telefono != docente.Usuario.NumeroTelefono).ToHashSet();
        HashSet<string> correos = context.Usuarios.Select(usuario => usuario.Correo).Where(correo => correo != docente.Usuario.Correo).ToHashSet();

        if(telefonos.Contains(nuevosDatosDocente.NuevoTelefono))
        {
            mensaje = "El numero de telefono ya esta siendo ocupado";
            return false;
        }
        else if(correos.Contains(nuevosDatosDocente.NuevoCorreo))
        {
            mensaje = "El correo ya esta siendo ocupado por otro usuario";
            return false;
        }

        docente.Usuario.Nombre = nuevosDatosDocente.NuevoNombre;
        docente.Usuario.NumeroTelefono = nuevosDatosDocente.NuevoTelefono;
        docente.Usuario.FechaNacimiento = nuevosDatosDocente.NuevaFechaNacimiento;
        docente.Usuario.Correo = nuevosDatosDocente.NuevoCorreo;
        docente.Especialidad = nuevosDatosDocente.NuevaMateria;
        docente.Grado = nuevosDatosDocente.NuevoGrado;
        docente.Experiencia = nuevosDatosDocente.NuevoAnhosExperiencia;
        docente.Usuario.Contrasenha = nuevosDatosDocente.NuevaContrasena;

        context.SaveChanges();
        return true;
    }
}
