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


}