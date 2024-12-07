using PostulacionDocente.ServicesApp.Models;

public interface IMateriaService
{
    public void anhadirMateria();
    public void eliminarMateria();
    public void conseguirMateria();
    public List<MateriaDTO> conseguirMaterias(PostulacionDocenteContext context);
    public List<CarreraMateriasDTO> ConseguirMateriasPorCarrera(PostulacionDocenteContext context);
}