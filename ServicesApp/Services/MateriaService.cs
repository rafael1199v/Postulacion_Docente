using PostulacionDocente.ServicesApp.Models;

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

    public List<MateriaDTO> conseguirMaterias(PostulacionDocenteContext context){

        // var materias = new List<MateriaDTO>(){
        //     new MateriaDTO{nombre = "Materia1", sigla = "M1"},
        //     new MateriaDTO{nombre = "Materia2", sigla = "M2"},
        //     new MateriaDTO{nombre = "Materia3", sigla = "M3"}
        // };

        var materias = (from _materia in context.Materia
                        select new MateriaDTO{
                            nombre = _materia.NombreMateria,
                            sigla = _materia.Sigla
                        }).ToList();

        return materias;
    }

    public List<CarreraMateriasDTO> ConseguirMateriasPorCarrera(PostulacionDocenteContext context)
    {
        var carreraMaterias = (from _carrera in context.Carreras
                              select new CarreraMateriasDTO{
                                NombreCarrera = _carrera.NombreCarrera,
                                SiglaCarrera = _carrera.Sigla,
                                NombreMaterias = _carrera.Materia.Select(m => m.NombreMateria).ToList()
                              }).ToList();

        
        return carreraMaterias;
    }

    public List<MateriaDTO> ConseguirMateriasJefeCarrera(PostulacionDocenteContext context, string CI)
    {
        var jefeCarreraId = (from _jefeCarrera in context.JefeCarreras
                             where _jefeCarrera.Usuario.Ci == CI
                             select _jefeCarrera.JefeCarreraId).FirstOrDefault<int>();

    
        var materias = (from _materia in context.Materia
                        where _materia.Carreras.Any(c => c.JefeCarreraId == jefeCarreraId)
                        select new MateriaDTO {
                            nombre = _materia.NombreMateria,
                            sigla = _materia.Sigla
                        }).ToList<MateriaDTO>();

        return materias;
    }
}