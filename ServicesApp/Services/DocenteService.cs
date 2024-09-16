public class DocenteService : IDocenteService{
    public void guardarDatosDocente(Docente? nuevoDocente){
        //appDbContext.Docente.Add(nuevoDocente);
        //appDbContext.SaveChanges();
        Console.WriteLine("Datos del docente");
        Console.WriteLine(nuevoDocente?.datosPersonales?.nombre);
        Console.WriteLine(nuevoDocente?.experiencia);
        Console.WriteLine("Se ha guardado los datos del docente");
    }
    public void verEstado(){

    }

    public Docente? conseguirDocente(string CarnetIdentidad){

        List<Docente> docentes = new List<Docente>(){
            new Docente{datosPersonales = new Usuario{CI = "13774782"}, materia = "Programacion", experiencia = 2, grado = "Ingeniero"},
            new Docente{datosPersonales = new Usuario{CI = "10990989"}, materia = "Medicina", experiencia = 10, grado = "Medico"},
            new Docente{datosPersonales = new Usuario{CI = "6340865"}, materia = "Derechos Penales", experiencia = 2, grado = "Licenciado"}
        };

       Docente? docente = null;

        foreach(Docente doc in docentes)
        {
            if(doc?.datosPersonales?.CI == CarnetIdentidad)
            {
                docente = doc;
                break;
            }
        }
        return docente;
    }


}