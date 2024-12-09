using PostulacionDocente.ServicesApp.Models;

public class DocenteService : IDocenteService{
    public void guardarDatosDocente(DocenteDTO? nuevoDocente){
        //appDbContext.Docente.Add(nuevoDocente);
        //appDbContext.SaveChanges();
        Console.WriteLine("Datos del docente");
        Console.WriteLine(nuevoDocente?.nombre);
        Console.WriteLine(nuevoDocente?.experiencia);
        Console.WriteLine("Se ha guardado los datos del docente");
    }
    public void verEstado(){

    }

    public DocenteDTO? conseguirDocente(string CarnetIdentidad){

        List<DocenteDTO> docentes = new List<DocenteDTO>(){
            new DocenteDTO{CI = "13774782", materia = "Programacion", experiencia = 2, grado = "Ingeniero"},
            new DocenteDTO{CI = "10990989", materia = "Medicina", experiencia = 10, grado = "Medico"},
            new DocenteDTO{CI = "6340865", materia = "Derechos Penales", experiencia = 2, grado = "Licenciado"}
        };

       DocenteDTO? docente = null;

        foreach(DocenteDTO doc in docentes)
        {
            if(doc?.CI == CarnetIdentidad)
            {
                docente = doc;
                break;
            }
        }
        return docente;
    }

    public DocentePerfilDTO? ConseguirDetallesDocente(PostulacionDocenteContext context,string usuarioCI)
    {
        var docente = (from _usuario in context.Usuarios
                      join _docente in context.Docentes on _usuario.UsuarioId equals _docente.UsuarioId
                      where _usuario.Ci == usuarioCI
                      select new DocentePerfilDTO {
                        Nombre = _usuario.Nombre,
                        Telefono = _usuario.NumeroTelefono,
                        CI = _usuario.Ci,
                        Materia = _docente.Especialidad,
                        Grado = _docente.Grado,
                        Correo = _usuario.Correo,
                        AnhosExperiencia = _docente.Experiencia,
                        DescripcionPersonal = _docente.DescripcionPersonal
                      }).FirstOrDefault<DocentePerfilDTO>();


        return docente;
    }

    public bool Postularse(PostulacionDocenteContext context, NuevaPostulacionDTO nuevaPostulacion, out string mensaje)
    {
        mensaje = "Se ha postulado correctamente";

        Docente? docente = (from _docente in context.Docentes
                        join _usuario in context.Usuarios on _docente.UsuarioId equals _usuario.UsuarioId
                        where _usuario.Ci == nuevaPostulacion.CI
                        select _docente).FirstOrDefault<Docente>();

       
        if(docente == null)
        {
            mensaje = "Hubo un error al registrar la docente en la vacante. Intentelo otra vez";
            return false;
        }
        else if(nuevaPostulacion.FechaFinalizacionVacante < DateTime.Now)
        {
            mensaje = "La vacante a dejado de ser vigente. Recargue la pagina";
            return false;
        }

        Postulacion nuevaPos = new Postulacion{
            EstadoId = 1,
            DocenteId = docente.DocenteId,
            VacanteId = nuevaPostulacion.VacanteId,
            Docente = docente
        };


        context.Postulacions.Add(nuevaPos);
        context.SaveChanges();

        return true;
    }
}