public class MateriaService : IMateriaService
{
    public void anhadirMateria()
    {
        System.Console.WriteLine("Se anhadio nueva materia");
    }
    public void eliminarMateria()
    {
        System.Console.WriteLine("Se elimino una materia");
    }
    public void conseguirMateria()
    {
        System.Console.WriteLine("Conseguir materia");
    }

    public List<Materia> conseguirMaterias(){

        var materias = new List<Materia>(){
            new Materia{nombre = "Materia1", sigla = "M1"},
            new Materia{nombre = "Materia2", sigla = "M2"},
            new Materia{nombre = "Materia3", sigla = "M3"}
        };

        return materias;
    }
}