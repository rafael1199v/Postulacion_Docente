public class DocenteService : IDocenteService{
    public void guardarDatosDocente(Docente nuevoDocente){
        //appDbContext.Docente.Add(nuevoDocente);
        //appDbContext.SaveChanges();

        Console.WriteLine("Se ha guardado los datos del docente");
    }
    public void verEstado(){

    }

}