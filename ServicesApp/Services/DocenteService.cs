public class DocenteService : IDocenteService
{
    public void guardarDatosDocente(Docente? nuevoDocente)
    {
        Console.WriteLine("Datos del docente");
        Console.WriteLine(nuevoDocente?.datosPersonales?.nombre);
        Console.WriteLine(nuevoDocente?.experiencia);
        Console.WriteLine("Se ha guardado los datos del docente");
    }
    public void verEstado()
    {

    }

    public Docente conseguirDocente(int usuarioId)
    {

        var docente = new Docente { datosPersonales = new Usuario(), materia = "Programacion", experiencia = 2, grado = "Ingeniero" };

        return docente;
    }


}