using PostulacionDocente.ServicesApp.Models;

public class RegistroService : IRegistroService
{
    public bool CredencialesEnUsoDocente(DocenteRegistroDTO docente, PostulacionDocenteContext context)
    {
       
       var usuario = (from _usuario in context.Usuarios
                        where _usuario.Correo == docente.Correo || _usuario.Ci == docente.CI
                        select _usuario).FirstOrDefault<Usuario>();


        if(usuario == null)
        {
            return false;
        }

        return true;
    }

    public bool CredencialesEnUsoJefeCarrera(JefeCarreraRegistroDTO jefeCarrera, PostulacionDocenteContext context)
    {
        
        var usuario = (from _usuario in context.Usuarios
                        where _usuario.Correo == jefeCarrera.Correo || _usuario.Ci == jefeCarrera.CI
                        select 
                        _usuario).FirstOrDefault<Usuario>();
        


       var carreraEnUso = (from _carrera in context.Carreras
                            where _carrera.CarreraId == jefeCarrera.CarreraId
                            select _carrera).FirstOrDefault<Carrera>();


        if(usuario != null || carreraEnUso != null)
        {
            return false;
        }


        return true;
    }

    public bool RegistrarDocente(DocenteRegistroDTO docente, PostulacionDocenteContext context)
    {
        if(CredencialesEnUsoDocente(docente, context))
        {
            return false;
        }
        

        var usuario = new Usuario{
            Nombre = docente.Nombre,
            Ci = docente.CI,
            FechaNacimiento = docente.FechaNacimiento,
            NumeroTelefono = docente.Telefono,
            Correo = docente.Correo,
            Contrasenha = docente.Contrasenha
        };

        var docenteDB  = new Docente
        {
            Especialidad = docente.Materia,
            Experiencia = docente.AnhosExperiencia,
            DescripcionPersonal = $"Hola soy {docente.Nombre}",
            Grado = docente.Grado,
            Usuario = usuario
        };


        return true;
    }

    public bool RegistrarJefeCarrera(JefeCarreraRegistroDTO jefeCarrera, PostulacionDocenteContext context)
    {
        if(CredencialesEnUsoJefeCarrera(jefeCarrera, context))
        {
            return false;
        }


        var usuario = new Usuario{
            Nombre = jefeCarrera.Nombre,
            Ci = jefeCarrera.CI,
            FechaNacimiento = jefeCarrera.FechaNacimiento,
            NumeroTelefono = jefeCarrera.Telefono,
            Correo = jefeCarrera.Correo,
            Contrasenha = jefeCarrera.Contrasenha
        };

        var jefeCarreraDB = new JefeCarrera
        {
            Usuario = usuario
        };



        return true;
    }
}